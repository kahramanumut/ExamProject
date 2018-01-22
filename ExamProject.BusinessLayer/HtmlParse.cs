using ExamProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.BusinessLayer
{
    public class HtmlParse
    {

        private string GetHtmlContent(string urlAddress)
        {
            Uri url = new Uri(urlAddress);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string html = client.DownloadString(url);
            return html;
        }

        private List<string> GetPageLink()
        {
            List<string> links = new List<string>();
            string url = "https://www.wired.com";

            string htmlContent = GetHtmlContent(url);

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlContent);

            for (int i = 1; i < 6; i++)
            {
                var node = document.DocumentNode.SelectSingleNode(SelectXPathWithPageId(i));
                links.Add(url + node.Attributes[0].DeEntitizeValue);
            }
            return links;
        }

        private string SelectXPathWithPageId(int pageId)
        {
            string pageXPath = "";

            switch (pageId)
            {
                case 1:
                    pageXPath = "//*[@id='app-root']/div/div[3]/div/div[2]/div[2]/div[1]/div/div[1]/div[1]/div[1]/div/ul/li[2]/a[2]";
                    break;
                case 2:
                    pageXPath = "//*[@id='app-root']/div/div[3]/div/div[2]/div[2]/div[1]/div/div[1]/div[1]/div[2]/div/ul/li[1]/a";
                    break;
                case 3:
                    pageXPath = "//*[@id='app-root']/div/div[3]/div/div[2]/div[2]/div[1]/div/div[1]/div[2]/div[1]/div[1]/div/ul/li[1]/a";
                    break;
                case 4:
                    pageXPath = "//*[@id='app-root']/div/div[3]/div/div[2]/div[2]/div[1]/div/div[1]/div[2]/div[2]/div/ul/li[1]/a";
                    break;
                case 5:
                    pageXPath = "//*[@id='app-root']/div/div[3]/div/div[2]/div[2]/div[1]/div/div[1]/div[2]/div[1]/div[2]/div/ul/li[1]/a";
                    break;
                default:
                    break;
            }

            return pageXPath;
        }

        public List<Question> GetTextandTitle()
        {
            List<Question> questionList = new List<Question>();

            for (int i = 0; i < 5; i++)
            {
                Question question = new Question();
                string htmlContent = GetHtmlContent(GetPageLink()[i].ToString());
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(htmlContent);

                //Wired.com haber içeriği başlığı büyük olduğunda xPath değişikliği
                var title = document.DocumentNode;
                if (document.DocumentNode.SelectSingleNode("//*[@id='articleTitleFull']") != null)
                    title = document.DocumentNode.SelectSingleNode("//*[@id='articleTitleFull']");
                else
                    title = document.DocumentNode.SelectSingleNode("//*[@id='articleTitle']");

                question.QuestionTitle = title.InnerText;

                // Wired.com'daki haber fotoğraf içerikli ise xPath i değiştirmek için kontrol
                var text = document.DocumentNode;
                if (document.DocumentNode.SelectSingleNode("//*[@id='app-root']/div/div[3]/div/div[4]/div/div[2]/main/article/div/p[1]") != null)
                    text = document.DocumentNode.SelectSingleNode("//*[@id='app-root']/div/div[3]/div/div[4]/div/div[2]/main/article/div/p[1]");
                else if (document.DocumentNode.SelectSingleNode("//*[@id='app-root']/div/div[3]/div/div[3]/div[2]/div/main/article/div[1]/section[1]/p[4]") != null)
                    text = document.DocumentNode.SelectSingleNode("//*[@id='app-root']/div/div[3]/div/div[3]/div[2]/div/main/article/div[1]/section[1]/p[4]");
                else
                    text = document.DocumentNode.SelectSingleNode("//*[@id='app-root']/div/div[3]/div/div[3]/div[2]/div/main/article/div/p[1]");

                question.QuestionText = text.InnerText;

                questionList.Add(question);
            }

            return questionList;
        }

    }
}
