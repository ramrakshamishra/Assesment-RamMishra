namespace Assessment_RaceTrack.Helper
{
    public static class Utility
    {
        public static string GetValueFromResources(string resourcesKey)
        {
            return RaceTrack.ResourceManager.GetString(resourcesKey);
        }
    }
}