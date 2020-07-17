using System;
using System.Collections.Generic;
using static System.String;

namespace RaytracingWPF_CT.Render
{
    public static class Parser
    {
        private static int Width { get; set; }
        private static int Height { get; set; }

        public static Scene Parse(string input)
        {
            Scene scene;
            input = input.Replace(" ", Empty);
            input = input.ToUpper();
            string[] lines = input.Split('\n');

            string[] param = lines[0].Split(',');

            try
            {
                Width = Convert.ToInt32(param[0]);
                Height = Convert.ToInt32(param[1]);
                scene = new Scene(Width, Height);
            }
            catch
            {
                EPrint(1, input);
                throw new Exception("ParseException:\tCould not parse the scene Size.");
            }

            int i = 0;
            try
            {
                for (i = 1; i < lines.Length; i++)
                {
                    char[] splitChars = {',', '(', ')'};
                    param = lines[i].Split(splitChars);
                    switch (param[0])
                    {
                        case "S":
                            scene.AddPrimitive(ToSphere(param));
                            break;
                    }
                }
            }
            catch
            {
                EPrint(i, input);
                throw new Exception("ParseException:\tCould not parse all the Primitives.");
            }

            return scene;
        }

        private static Sphere ToSphere(IReadOnlyList<string> param)
        {
            Vec3 origin = ToVec3(param[1]);

            double radius = Convert.ToDouble(param[2]);

            Vec3 colorVec = ToVec3(param[3]);
            byte r = Convert.ToByte(colorVec.X1);
            byte g = Convert.ToByte(colorVec.X2);
            byte b = Convert.ToByte(colorVec.X3);
            Color color = new Color(r, g, b);

            return new Sphere(origin, radius, color);
        }

        private static Vec3 ToVec3(string input)
        {
            string[] coordinates = input
                .Replace("[", Empty)
                .Replace("]", Empty)
                .Split(';');
            double x1 = Convert.ToDouble(coordinates[0]);
            double x2 = Convert.ToDouble(coordinates[1]);
            double x3 = Convert.ToDouble(coordinates[2]);

            return new Vec3(x1, x2, x3);
        }

        private static void EPrint(int line, string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"ERROR: 	 Could not parse line {0}", line + 1);
            Console.ForegroundColor = ConsoleColor.Green;
            string[] lines = input.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                if (line == i) Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" [{0}]:\t{1}", i + 1, lines[i]);
                if (line != i) continue;
                Console.WriteLine(" ...");
                break;
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}