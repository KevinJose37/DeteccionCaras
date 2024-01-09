using System;
using System.IO;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;

class Program
{
    static void Main()
    {
        string rutaVideo = "C:/Users/USER/Downloads/Video/PersonaCara.mp4";
        string carpetaCaras = "C:/Users/USER/Downloads/Caras";

        AnalizarCarasEnTiempoReal(rutaVideo, carpetaCaras);
    }

    static void AnalizarCarasEnTiempoReal(string rutaVideo, string carpetaCaras)
    {
        Console.WriteLine("Cargando los clasificadores de caras, ojos, nariz y boca");
        string haarcascadeFacePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "haarcascades", "haarcascade_frontalface_alt_tree.xml");
        string haarcascadeEyePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "haarcascades", "haarcascade_mcs_eyepair_big.xml");
        string haarcascadeNosePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "haarcascades", "haarcascade_mcs_nose.xml");


        CascadeClassifier faceClassifier = new CascadeClassifier(haarcascadeFacePath);
        CascadeClassifier eyeClassifier = new CascadeClassifier(haarcascadeEyePath);
        CascadeClassifier noseClassifier = new CascadeClassifier(haarcascadeNosePath);


        Console.WriteLine("Clasificadores cargados");

        using (VideoCapture capture = new VideoCapture(rutaVideo))
        {
            int frameRate = (int)capture.Get(CapProp.Fps);
            int frameActual = 0;

            while (true)
            {
                Mat frame = new Mat();
                capture.Read(frame);

                if (frame.IsEmpty)
                    break;

                Mat grayFrame = new Mat();
                CvInvoke.CvtColor(frame, grayFrame, ColorConversion.Bgr2Gray);

                // Detección de caras
                Rectangle[] caras = faceClassifier.DetectMultiScale(grayFrame);

                foreach (var cara in caras)
                {
                    // Extraer la región que encierra la cara
                    Mat regionCara = new Mat(frame, cara);

                    // Guardar la región de la cara en una nueva imagen
                    string nombreArchivoCara = $"{frameActual}_cara.png";
                    string rutaCaraSalida = Path.Combine(carpetaCaras, nombreArchivoCara);
                    CvInvoke.Imwrite(rutaCaraSalida, regionCara);

                    // Dibujar rectángulo alrededor de la cara detectada en el frame original
                    CvInvoke.Rectangle(frame, cara, new MCvScalar(0, 255, 0), 2);

                    // Detección de ojos dentro de cada cara detectada
                    Rectangle[] ojos = eyeClassifier.DetectMultiScale(regionCara.ToImage<Gray, byte>());

                    foreach (var ojo in ojos)
                    {
                        // Crea una copia de la variable de iteración para modificarla
                        Rectangle ojoCopia = ojo;

                        // Ajusta la posición del ojo respecto a la cara
                        ojoCopia.X += cara.X;
                        ojoCopia.Y += cara.Y;

                        // Extraer la región que encierra el ojo
                        Mat regionOjo = new Mat(frame, ojoCopia);

                        // Guardar la región del ojo en una nueva imagen
                        string nombreArchivoOjo = $"{frameActual}_ojo.png";
                        string rutaOjoSalida = Path.Combine(carpetaCaras, nombreArchivoOjo);
                        CvInvoke.Imwrite(rutaOjoSalida, regionOjo);

                        // Dibujar rectángulo alrededor del ojo detectado en el frame original
                        CvInvoke.Rectangle(frame, ojoCopia, new MCvScalar(255, 0, 0), 2);
                    }

                    // Detección de nariz dentro de cada cara detectada
                    Rectangle[] narices = noseClassifier.DetectMultiScale(regionCara.ToImage<Gray, byte>());

                    foreach (var nariz in narices)
                    {
                        // Crea una copia de la variable de iteración para modificarla
                        Rectangle narizCopia = nariz;

                        // Ajusta la posición de la nariz respecto a la cara
                        narizCopia.X += cara.X;
                        narizCopia.Y += cara.Y;

                        // Extraer la región que encierra la nariz
                        Mat regionNariz = new Mat(frame, narizCopia);

                        // Guardar la región de la nariz en una nueva imagen
                        string nombreArchivoNariz = $"{frameActual}_nariz.png";
                        string rutaNarizSalida = Path.Combine(carpetaCaras, nombreArchivoNariz);
                        CvInvoke.Imwrite(rutaNarizSalida, regionNariz);

                        // Dibujar rectángulo alrededor de la nariz detectada en el frame original
                        CvInvoke.Rectangle(frame, narizCopia, new MCvScalar(0, 0, 255), 2);
                    }

                    
                    // Mostrar el frame con las caras, ojos, narices y bocas resaltados en tiempo real
                    CvInvoke.Imshow("Video con Caras, Ojos, Narices", frame);
                    CvInvoke.WaitKey(1);

                    frameActual++;
                }
            }
        }
    }
}