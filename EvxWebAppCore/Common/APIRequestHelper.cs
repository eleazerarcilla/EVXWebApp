using EvxWebAppCore.Common;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EvxWebAppCore.Common
{
    public class APIRequestHelper
    {
        Logger _logger = LogManager.GetLogger("EVX-APIRequestHelper");
        public APIRequestHelper() { }

        public async Task<string> SendRequest(RequestData data)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpRequestMessage requestMessage = new HttpRequestMessage();
                    requestMessage.RequestUri = new Uri($"{data.APIBaseAddress}{data.FunctionName}{data.Paramters}"); //URL of APi method
                    requestMessage.Method = data.Method;
                    if (data.JSONData != null)
                        requestMessage.Content = new StringContent(data.JSONData, Encoding.UTF8, data.ContentType);
                    using (var c_token = new CancellationTokenSource())
                    {
                        c_token.CancelAfter(TimeSpan.FromSeconds(120)); //2 minutes timeout
                        return await (await client.SendAsync(requestMessage, c_token.Token).ConfigureAwait(false)).Content.ReadAsStringAsync();
                    }
                }
            }catch(TaskCanceledException ex)
            {
                if (!ex.CancellationToken.IsCancellationRequested)
                    return "The request timed out.";
            }
            catch (WebException webex)
            {
                _logger.Error(webex);
                return $"SendRequest() : {webex.InnerException.Message}";
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return $"SendRequest() : {ex.InnerException.Message}";
            }
            return string.Empty;
        }
    }
  
}
