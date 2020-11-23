using OpenCvSharp;
using System;

namespace OpenCVColorExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string inputFilePath = "Images/gauge-1.jpg";

            //画像を読み込み
            var src = Cv2.ImRead(inputFilePath);
            if (src is null)
                Console.WriteLine("fail to read file.");

            
            
        }


        //抽出したい色の範囲をRGBで指定
        const int B_MAX = 40;
        const int B_MIN = 0;
        const int G_MAX = 50;
        const int G_MIN = 0;
        const int R_MAX = 170;
        const int R_MIN = 100;
        private static void ExtractColorByRGB(Mat src)
        {
            //マスクを作成
            Scalar s_min = new Scalar(B_MIN, G_MIN, R_MIN);
            Scalar s_max = new Scalar(B_MAX, G_MAX, R_MAX);
            Mat maskImage = new Mat();
            Cv2.InRange(src, s_min, s_max, maskImage);


            //マスクを使ってフィルタリング
            Mat masked = new Mat();
            src.CopyTo(masked, maskImage);


            //HSVに変換
            Mat hsv = new Mat();
            Cv2.CvtColor(src, hsv, ColorConversionCodes.RGB2HSV);

            //表示
            using (new Window("src", src))
            //using (new Window("hsv", hsv))
            using (new Window("maskImage", maskImage))
            using (new Window("masked", masked))
                Cv2.WaitKey();//何かキーが押されるまで待つ
        }
    }
}
