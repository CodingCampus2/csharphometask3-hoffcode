using System;
using CodingCampusCSharpHomework;

namespace HomeworkTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Task3, string> TaskSolver = task =>
            {

                string strUserLongitude = task.UserLongitude;
                float userLongitude = LoadFloatFromString(strUserLongitude);

                string strUserLatitude = task.UserLatitude;
                float userLatitude = LoadFloatFromString(strUserLatitude);

                float minDistance = float.MaxValue;
                int minDistanceIndex = -1;

                int placesCount = task.DefibliratorStorages.Length;
                for (int i = 0; i < placesCount; i++)
                {
                    string defibrillatorStorage = task.DefibliratorStorages[i];
                    string[] storageData = defibrillatorStorage.Split(';');

                    string strLongitude = storageData[2];
                    float longitude = LoadFloatFromString(strLongitude);

                    string strLatitude = storageData[3];
                    float latitude = LoadFloatFromString(strLatitude);

                    float d = CalculateDistance(longitude, latitude, userLongitude, userLatitude);

                    if (d < minDistance)
                    {
                        minDistance = d;
                        minDistanceIndex = i;
                    }
                }

                string[] closestStorageData = task.DefibliratorStorages[minDistanceIndex].Split(';');
                string name = closestStorageData[0];
                string address = closestStorageData[1];
                return $"Name: {name}; Address: {address}";
            };

            Task3.CheckSolver(TaskSolver);
        }
        
        static float LoadFloatFromString(string str)
        {
            str.Replace(',', '.');
            return float.Parse(str);
        }

        static float CalculateDistance(float longitudeA, float latitudeA, float longitudeB, float latitudeB)
        {
            const float EARTH_RADIUS = 6371;

            float x = (longitudeB - longitudeA) * MathF.Cos((latitudeA + latitudeB) / 2f);
            float y = (latitudeB - latitudeA);

            return MathF.Sqrt((x * x) + (y * y)) * EARTH_RADIUS;
        }
    }
}
