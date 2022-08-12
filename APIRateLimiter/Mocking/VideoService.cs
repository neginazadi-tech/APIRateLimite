using Newtonsoft.Json;

namespace APIRateLimiter.Mocking
{
    public class VideoService
    {
        //Via constructors
        public IFileReader FileReader;
        public VideoService(IFileReader fileReader)
        {
            FileReader = fileReader ?? new FileReader();
        }
        public string ReadVideoTitle()
        {
            var str = FileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";

            return video.Title;
        }

        private class Video
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public bool IsProcessed { get; set; }
        }
    }

}
