using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text;
using System.Xml.Linq;
using static HuffmanCompression;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace MMS_Projekat
{
    public partial class Form1 : Form
    {
        private Bitmap m_Bitmap;
        private double Zoom = 1.0;
        private Stack<Bitmap> m_UndoStack;
        private Dictionary<byte, string> kodovi;
        private BitArray bitArray;
        private byte[] yuv_Bytes;




        public Form1()
        {
            InitializeComponent();
            m_Bitmap = new Bitmap(1, 1);
            m_UndoStack = new Stack<Bitmap>();
            kodovi= new Dictionary<byte, string>();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(m_Bitmap, new Rectangle(this.AutoScrollPosition.X, this.AutoScrollPosition.Y + menuStrip1.Height, (int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom)));
        }

        #region ConversionCompressionDownsampling
        //konvertuje rgb u yuv i downsampluje po potrebi; rezultat smesta u yuv_Bytes
        private void convertRGBtoYUV(bool downsample)
        {
            int size = m_Bitmap.Width * m_Bitmap.Height;
            if (downsample)
            {
                byte[] yChannel = new byte[size];
                byte[] uChannel = new byte[size / 2 + 1];
                byte[] vChannel = new byte[size / 2 + 1];

                int yIndex = 0;
                int uIndex = 0;
                int vIndex = 0;


                BitmapData bmData = m_Bitmap.LockBits(new Rectangle(0, 0, m_Bitmap.Width, m_Bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                int stride = bmData.Stride;
                System.IntPtr Scan0 = bmData.Scan0;

                unsafe
                {
                    byte* p = (byte*)(void*)Scan0;
                    byte r, g, b;
                    int yValue, uValue, vValue, xmod, ymod;


                    int nOffset = stride - m_Bitmap.Width * 3;

                    for (int y = 0; y < m_Bitmap.Height; ++y)
                    {
                        for (int x = 0; x < m_Bitmap.Width; ++x)
                        {

                            r = p[2];
                            g = p[1];
                            b = p[0];

                            // Convert RGB to YUV
                            yValue = (byte)(0.299 * r + 0.587 * g + 0.114 * b);

                            yValue = yValue < 0 ? 0 : yValue > 255 ? 255 : yValue;

                            yChannel[yIndex++] = (byte)yValue;

                            xmod = x % 4;
                            ymod = y % 4;

                            if (((xmod == 0 || xmod == 1) && (ymod == 0 || ymod == 1)) ||
                                ((xmod == 2 || xmod == 3) && (ymod == 2 || ymod == 3)))
                            {
                                    uValue = (byte)(0.492 * (b - yValue) + 128);
                                    vValue = (byte)(0.877 * (r - yValue) + 128);

                                    uValue = uValue < 0 ? 0 : uValue > 255 ? 255 : uValue;
                                    vValue = vValue < 0 ? 0 : vValue > 255 ? 255 : vValue;

                                    uChannel[uIndex++] = (byte)uValue;
                                    vChannel[vIndex++] = (byte)vValue;

                            }

                            p += 3;
                        }

                        p += nOffset;
                    }
                }

                m_Bitmap.UnlockBits(bmData);
                yuv_Bytes = yChannel.Concat(uChannel).Concat(vChannel).ToArray();
                              
            }
            else
            {

                byte[] yChannel = new byte[size];
                byte[] uChannel = new byte[size];
                byte[] vChannel = new byte[size];

                int yIndex = 0;
                int uIndex = 0;
                int vIndex = 0;

                BitmapData bmData = m_Bitmap.LockBits(new Rectangle(0, 0, m_Bitmap.Width, m_Bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                int stride = bmData.Stride;
                System.IntPtr Scan0 = bmData.Scan0;

                unsafe
                {
                    byte* p = (byte*)(void*)Scan0;
                    byte r, g, b;
                    int yValue, uValue, vValue, xmod, ymod;


                    int nOffset = stride - m_Bitmap.Width * 3;

                    for (int y = 0; y < m_Bitmap.Height; ++y)
                    {
                        for (int x = 0; x < m_Bitmap.Width; ++x)
                        {

                            r = p[2];
                            g = p[1];
                            b = p[0];

                            // Convert RGB to YUV
                            yValue = (byte)(0.299 * r + 0.587 * g + 0.114 * b);
                            uValue = (byte)(0.492 * (b - yValue) + 128);
                            vValue = (byte)(0.877 * (r - yValue) + 128);


                            yValue = yValue < 0 ? 0 : yValue > 255 ? 255 : yValue;
                            uValue = uValue < 0 ? 0 : uValue > 255 ? 255 : uValue;
                            vValue = vValue < 0 ? 0 : vValue > 255 ? 255 : vValue;

                            yChannel[yIndex++] = (byte)yValue;
                            uChannel[uIndex++] = (byte)uValue;
                            vChannel[vIndex++] = (byte)vValue;

                            p += 3;
                        }

                        p += nOffset;
                    }
                }

                m_Bitmap.UnlockBits(bmData);
                yuv_Bytes = yChannel.Concat(uChannel).Concat(vChannel).ToArray();
            }



        }

        //konvertuje yuv u rgb i upsampluje po potrebi; rekreira bitmapu
        private void convertYUVtoRGB(bool downsample)
        {

            int size = m_Bitmap.Width * m_Bitmap.Height;

            if (downsample)
            {
                BitmapData bmData = m_Bitmap.LockBits(new Rectangle(0, 0, m_Bitmap.Width, m_Bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                int stride = bmData.Stride;
                System.IntPtr Scan0 = bmData.Scan0;

                unsafe
                {
                    int halfSize = size / 2 + 1;

                    byte[] yChannel = new byte[size];
                    byte[] uChannel = new byte[halfSize];
                    byte[] vChannel = new byte[halfSize];
                    byte[] uChannelUpsampled = new byte[size];
                    byte[] vChannelUpsampled = new byte[size];


                    //inicijalizacija yuv kanala (u,v su downsamplovani)
                    for (int i = 0; i < size; i++)
                    {
                        yChannel[i] = yuv_Bytes[i];
                    }


                    for (int i = 0; i < halfSize; i++)
                    {
                        uChannel[i] = yuv_Bytes[i + size];
                        vChannel[i] = yuv_Bytes[i + size + halfSize];

                    }


                    byte* p = (byte*)(void*)Scan0;
                    int r, g, b;
                    int xmod, ymod;
                    int channelIndex = 0;
                    int nOffset = stride - m_Bitmap.Width * 3;


                    //upsample u i v kanala i setovanje r g b vrednosti bitmape
                    for (int y = 0; y < m_Bitmap.Height; y++)
                    {
                        for (int x = 0; x < m_Bitmap.Width; x++)
                        {
                            int linearIndex = x + y * m_Bitmap.Width;

                            xmod = x % 4;
                            ymod = y % 4;



                            if (((xmod == 0 || xmod == 1) && (ymod == 0 || ymod == 1)) ||
                               ((xmod == 2 || xmod == 3) && (ymod == 2 || ymod == 3)))
                            {
                                uChannelUpsampled[linearIndex] = uChannel[channelIndex];
                                vChannelUpsampled[linearIndex] = vChannel[channelIndex];
                                channelIndex++;

                            }
                            else if ((ymod == 0 || ymod == 1)&& xmod == 2)
                            {
                                uChannelUpsampled[linearIndex] = uChannel[channelIndex-2];
                                vChannelUpsampled[linearIndex] = vChannel[channelIndex-2];

                            }
                            else if ((ymod == 0 || ymod == 1) && xmod == 3)
                            {
                                uChannelUpsampled[linearIndex] = uChannel[channelIndex-1];
                                vChannelUpsampled[linearIndex] = vChannel[channelIndex-1];

                            }

                            else if ((ymod == 2 || ymod == 3) && xmod == 0)
                            {
                                uChannelUpsampled[linearIndex] = uChannel[channelIndex-1];
                                vChannelUpsampled[linearIndex] = vChannel[channelIndex-1];

                            }
                            else
                            {
                                uChannelUpsampled[linearIndex] = uChannel[channelIndex];
                                vChannelUpsampled[linearIndex] = vChannel[channelIndex];

                            }

                            // Convert YUV to RGB

                            int yInt = yChannel[linearIndex];
                            int uInt = uChannelUpsampled[linearIndex] - 128;
                            int vInt = vChannelUpsampled[linearIndex] - 128;

                            r = (int)(yInt + 1.14 * vInt);
                            g = (int)(yInt - 0.395 * uInt - 0.581 * vInt);
                            b = (int)(yInt + 2.032 * uInt);

                            r = r < 0 ? 0 : r > 255 ? 255 : r;
                            g = g < 0 ? 0 : g > 255 ? 255 : g;
                            b = b < 0 ? 0 : b > 255 ? 255 : b;

                            //set pixel rgb values
                            p[2] = (byte)r;
                            p[1] = (byte)g;
                            p[0] = (byte)b;


                            p += 3;
                            

                        }
                        p += nOffset;
                    }
                }
                m_Bitmap.UnlockBits(bmData);
            }
            else
            {
                BitmapData bmData = m_Bitmap.LockBits(new Rectangle(0, 0, m_Bitmap.Width, m_Bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                int stride = bmData.Stride;
                System.IntPtr Scan0 = bmData.Scan0;

                unsafe
                {
                    int nOffset = stride - m_Bitmap.Width * 3;
                    byte* p = (byte*)(void*)Scan0;

                    int r, g, b;
                    byte[] yChannel = new byte[size];
                    byte[] uChannel = new byte[size];
                    byte[] vChannel = new byte[size];

                    //inicijalizacija yuv kanala (nisu downsamplovani)
                    for(int i = 0; i < size; i++)
                    {
                        yChannel[i] = yuv_Bytes[i];
                        uChannel[i] = yuv_Bytes[i + size];
                        vChannel[i] = yuv_Bytes[i + size + size];                       
                    }


                    //rekreiranje bitmape
                    int linearIndex;
                    for (int y = 0; y < m_Bitmap.Height; y++)
                    {
                        for (int x = 0; x < m_Bitmap.Width; x++)
                        {
                            linearIndex = x + y * m_Bitmap.Width;

                            int yInt = yChannel[linearIndex];
                            int uInt = uChannel[linearIndex] - 128;
                            int vInt = vChannel[linearIndex] - 128;

                            r = (int)(yInt + 1.14 * vInt);
                            g = (int)(yInt - 0.395 * uInt - 0.581 * vInt);
                            b = (int)(yInt + 2.032 * uInt);

                            r = r < 0 ? 0 : r > 255 ? 255 : r;
                            g = g < 0 ? 0 : g > 255 ? 255 : g;
                            b = b < 0 ? 0 : b > 255 ? 255 : b;

                            //set pixel rgb values
                            p[2] = (byte)r;
                            p[1] = (byte)g;
                            p[0] = (byte)b;


                            p += 3;


                        }
                        p += nOffset;
                    }

                }
                m_Bitmap.UnlockBits(bmData);
            }



        }

        //kompresuje yuv_Bytes po bajtu ili polubajtu; rezultat smesta u yuv_Bytes
        private void compress(bool dictSyzeHalfByte)
        {
            Dictionary<byte, int> frekvencije;
            if (dictSyzeHalfByte)
            {
                List<byte> halfBytes = new List<byte>();

                foreach (byte b in yuv_Bytes)
                {
                    byte upperHalf = (byte)(b >> 4);    // Get the upper half-byte
                    byte lowerHalf = (byte)(b & 0x0F);  // Get the lower half-byte

                    halfBytes.Add(upperHalf);
                    halfBytes.Add(lowerHalf);
                }

                yuv_Bytes = halfBytes.ToArray();


            }

            frekvencije = HuffmanCompression.CountDataFrequencies(yuv_Bytes);


            var root = HuffmanCompression.BuildHuffmanTree(frekvencije);

            kodovi = HuffmanCompression.GenerateHuffmanCodes(root);//stvarna vrednost : kodirana vrednost

            bitArray = HuffmanCompression.CompressData(yuv_Bytes, kodovi); // kompresovani podaci u bitovima
            
            yuv_Bytes = new byte[bitArray.Length / 8 + (bitArray.Length % 8 == 0 ? 0 : 1)];
            bitArray.CopyTo(yuv_Bytes, 0); // kompresovani podaci u bajtovima




        }

        #endregion

        #region LoadAndSave
        //ucitavanje iz fajla; ako je custom format vrsi dekompresiju i upsampling po potrebi u zavisnosti od flega
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Bin files (*.bin)|*.bin|Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|GIF files(*.gif)|*.gif|PNG files(*.png)|*.png|All valid files|*.bin;*.bmp;*.jpg;*.gif;*.png";
            openFileDialog.FilterIndex = 6;
            openFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                m_UndoStack.Clear();
                if (Path.GetExtension(openFileDialog.FileName) == ".bin")
                {
                    //UCITAVANJE IZ FAJLA

                    Dictionary<string, byte> ucitaniKodovi = new Dictionary<string, byte>();
                    byte[] ucitaniBajtovi;

                    using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open))
                    using (BinaryReader reader = new BinaryReader(fileStream))
                    {

                        //ucitaj flegove
                        byte flags = reader.ReadByte();

                        //sirina bitmape
                        int bitmapWidth = reader.ReadInt32();

                        //visina bitmape
                        int bitmapHeight = reader.ReadInt32();

                        m_Bitmap = new Bitmap(bitmapWidth, bitmapHeight);

                        bool compressed = (flags & 1 ) != 0;
                        bool halfByte = ((flags>>1) & 1) != 0;
                        bool downsampled = ((flags >> 2) & 1) != 0;
                        int brojBitova = 0;
                        byte[] decompresed; 


                        //ako je kompresovano ucitaj podatke vezane za kompresiju (duzinu kompresovanih bitova, recnik, ...)
                        if (compressed)
                        {
                            brojBitova = reader.ReadInt32(); // broj kodiranih bitova
                            int duzinaRecnika = reader.ReadInt32();


                            for (int n = 0; n < duzinaRecnika; n++)
                            {
                                var value = reader.ReadByte();
                                var key = reader.ReadString();
                                ucitaniKodovi[key] = value;
                            }

                        }

                        //ucitaj broj kodiranih bajtova
                        int length = reader.ReadInt32();
                        //ucitaj kodirane bajtove
                        ucitaniBajtovi = reader.ReadBytes(length);

                        //ako je kompresovano uradi dekompresiju
                        if (compressed)
                        {
                            BitArray ucitaniBitovi = new BitArray(ucitaniBajtovi);
                            decompresed = HuffmanCompression.DecompressData(ucitaniBitovi, ucitaniKodovi, brojBitova);

                            //ako su polubajtovi spoji ih
                            if (halfByte)
                            {
                                yuv_Bytes = new byte[decompresed.Length / 2]; 
                                for(int i = 0; i < decompresed.Length / 2; i++)
                                {
                                    yuv_Bytes[i] = (byte)((decompresed[i*2]<<4)|decompresed[i*2+1]);
                                }
                            }
                            else
                            {
                                yuv_Bytes = new byte[decompresed.Length];
                                yuv_Bytes = decompresed;
                            }

                        }
                        else
                        {
                            yuv_Bytes = new byte[ucitaniBajtovi.Length];
                            yuv_Bytes = ucitaniBajtovi;
                        }

                        //konvertuj iz YUV u RGB i uradi upsampling ako je potrebno
                        this.convertYUVtoRGB(downsampled);

                        this.AutoScroll = true;
                        this.AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
                        this.Invalidate();


                    }
                }
                else
                {
                    m_Bitmap = (Bitmap)Bitmap.FromFile(openFileDialog.FileName, false);
                    this.AutoScroll = true;
                    this.AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
                    this.Invalidate();

                }
            }
        }

        //cuvanje u fajl; fajl je custom formata; model boja je YUV; moguce downsamplovanje i kompresija
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Filter = "Bin files (*.bin)|*.bin|Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|GIF files(*.gif)|*.gif|PNG files(*.png)|*.png";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;


            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {

                if (saveFileDialog.FileName == "")
                    return;

                //ako je izabran .bin format onda cuva u custom formatu
                if (Path.GetExtension(saveFileDialog.FileName) == ".bin")
                {
                    SaveOptions saveOptions = new SaveOptions();
                    if (DialogResult.OK == saveOptions.ShowDialog())
                {
                    this.convertRGBtoYUV(saveOptions.downsamplingChecked);

                    if (saveOptions.compressionChecked)
                        this.compress(saveOptions.hbRadioChecked);

                    using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    using (BinaryWriter writer = new BinaryWriter(fileStream))
                    {
                        //upisi flegove
                        //7,6,5,4,3,2 - downsampling,1 - polubit,0 - kompresija

                        List<bool> bits = new List<bool> { false, false, false, false, false, saveOptions.downsamplingChecked, saveOptions.hbRadioChecked, saveOptions.compressionChecked }; // Example list of bits
                        byte flags = 0;

                        for (int i = 0; i < 8; i++)
                        {
                            flags <<= 1;
                            flags |= (byte)(bits[i] ? 1 : 0); 
                        }


                        //upis flega
                        writer.Write(flags);


                        //upisi width i height bitmape
                        writer.Write(m_Bitmap.Width);
                        writer.Write(m_Bitmap.Height);


                        if (saveOptions.compressionChecked)
                        {
                            //upisi duzinu kodiranih bitova
                            writer.Write(bitArray.Count);

                            //upisi duzinu recnika .
                            writer.Write(kodovi.Count); // duzina recnika

                            //upisi recnik .
                            foreach (var obj in kodovi)
                            {
                                writer.Write(obj.Key);
                                writer.Write(obj.Value);
                            }
                        }

                        //upisi duzinu (kodiranih) bajtova 
                        writer.Write(yuv_Bytes.Length);

                        //upisi (kodirane) bajtove .
                        writer.Write(yuv_Bytes);


                        writer.Flush();

                    }


                }
                }
                else
                {
                    m_Bitmap.Save(saveFileDialog.FileName);
                }
            }
        }
        #endregion

        #region Filters
        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GammaInput dlg = new GammaInput();
            dlg.Red = dlg.Green = dlg.Blue = 1;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                m_UndoStack.Push((Bitmap)m_Bitmap.Clone());
                if (Filter.Gamma(m_Bitmap, dlg.Red, dlg.Green, dlg.Blue))
                    this.Invalidate();
            }


        }

        private void smoothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_UndoStack.Push((Bitmap)m_Bitmap.Clone());
            if (Filter.Smooth(m_Bitmap, 1))
                this.Invalidate();

        }

        private void edgeDetectVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_UndoStack.Push((Bitmap)m_Bitmap.Clone());
            if (Filter.EdgeDetectVertical(m_Bitmap))
                this.Invalidate();

        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_UndoStack.Push((Bitmap)m_Bitmap.Clone());
            if (Filter.TimeWarp(m_Bitmap,15,false))
                this.Invalidate();

        }

        private void antialiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_UndoStack.Push((Bitmap)m_Bitmap.Clone());
            if (Filter.TimeWarp(m_Bitmap, 15, true))
                this.Invalidate();

        }
        #endregion

        #region Zoom
        private void Zoom25_Click(object sender, EventArgs e)
        {
            Zoom = .25;
            this.AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
            this.Invalidate();
        }

        private void Zoom50_Click(object sender, EventArgs e)
        {
            Zoom = .5;
            this.AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
            this.Invalidate();
        }

        private void Zoom100_Click(object sender, EventArgs e)
        {
            Zoom = 1;
            this.AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
            this.Invalidate();
        }

        private void Zoom150_Click(object sender, EventArgs e)
        {
            Zoom = 1.5;
            this.AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
            this.Invalidate();
        }

        private void Zoom200_Click(object sender, EventArgs e)
        {
            Zoom = 2;
            this.AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
            this.Invalidate();
        }

        private void Zoom300_Click(object sender, EventArgs e)
        {
            Zoom = 3;
            this.AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
            this.Invalidate();
        }

        private void Zoom500_Click(object sender, EventArgs e)
        {
            Zoom = 5;
            this.AutoScrollMinSize = new Size((int)(m_Bitmap.Width * Zoom), (int)(m_Bitmap.Height * Zoom));
            this.Invalidate();
        }
        #endregion

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_UndoStack.Count > 0)
            {
                Bitmap temp = (Bitmap)m_Bitmap.Clone();
                m_Bitmap = (Bitmap)m_UndoStack.Pop().Clone();
            }

            this.Invalidate();
        }
    }
}