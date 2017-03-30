namespace OnlineAtelier.Logic
{
    using System.IO;

    public class GetImageData
    {
        public static byte[] GetIamge(string fileName)
        {
            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo(fileName);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imageData = br.ReadBytes((int)imageFileLength);

            return imageData;
        }
    }
}
