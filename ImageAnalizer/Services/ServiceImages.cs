using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace ImageAnalizer.Services
{
    public class ServiceImages
    {
        private Uri UriApi;
        // private MediaTypeWithQualityHeaderValue Header;
        private string Key;

        public ServiceImages(String uriapi, string clave)
        {
            // this.Header = new MediaTypeWithQualityHeaderValue("application/json");

            this.UriApi = new Uri(uriapi);
            this.Key = clave;
        }

        
        public async Task<ImageAnalysis> Analizer(string urlAnalize)
        {
            string subscriptionKey = "eeaf71b7af4b424f8784608593261774";
            string subscriptionKey2 = "90fa26632f7c49b8ae8723ae5a46ee40";
            string endpoint = "https://computervisionsrg.cognitiveservices.azure.com/";
            string ANALYZE_URL_IMAGE = urlAnalize;

            ComputerVisionClient client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey)) { Endpoint = endpoint };

            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
            {
                VisualFeatureTypes.Categories, VisualFeatureTypes.Description,
                VisualFeatureTypes.Faces, VisualFeatureTypes.ImageType,
                VisualFeatureTypes.Tags, VisualFeatureTypes.Adult,
                VisualFeatureTypes.Color, VisualFeatureTypes.Brands,
                VisualFeatureTypes.Objects
            };

            ImageAnalysis results = await client.AnalyzeImageAsync(ANALYZE_URL_IMAGE, visualFeatures: features);

            return results;
        }






        /*
         * 
         * 
         * 
        private T GetValue<T>(String value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }


        private async Task<T> CallApi<T>(string? urlAnalize)
        {
            var stringContent = new StringContent(urlAnalize.ToString());
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.Key);

            // Request parameters
            
            queryString["visualFeatures"] = "Categories";
            queryString["details"] = "{string}";
            queryString["language"] = "en";
            var uri = "https://southcentralus.api.cognitive.microsoft.com/vision/v3.0/analyze?" + queryString;
            
            var uri = this.UriApi;

            HttpResponseMessage response;


            char[] body = urlAnalize.ToCharArray();
            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes(body);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsJsonAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    var resultados = await content.ReadAsStringAsync();
                    T data = GetValue<T>(resultados);
                    //T data = await response.Content.ReadAsStringAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
            




            
                using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Ocp-Apim-Subscription-Key", this.Key);
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", this.Key);
                
                // HttpResponseMessage response = await client.GetAsync(request);
                

                HttpResponseMessage response = await client.PostAsync(this.UriApi, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
                

        }
        
        public async Task<List<String>> GetAnalize(string urlAnalize)
        {
            String cadena2 = "{\"url\":\" " + urlAnalize + "\"}";
            var cadena = await this.CallApi<String>(cadena2);
            JObject json = JObject.Parse(cadena);

            if (json.ContainsKey("description"))
            {
                string propiedades = json["description"]["tags"].ToString();
                List<Char> propiedadesArr = propiedades.ToList();
                List<String> atributos =  propiedadesArr.Select(c => c.ToString()).ToList();
                //var mystring = new string(propiedadesArr.ToArray());
                // List<String> atributos = new List<string>(mystring);
                return atributos;
            } else
            {
                return new List<string> { "atributo", "vacio, fallo grave" };
            }
            // return json;
        }
        */

    }
}
