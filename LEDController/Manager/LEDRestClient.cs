using LEDController.Dtos;
using LEDController.Interfaces;
using LEDController.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace LEDController.Manager
{
    public class LedRestClient : ILedClient
    {
        private RestClient _HttpClient { get; set; }

        private MyColor.RGB[] _Buffer { get; set; }

        private string _URLWithPort { get; set; }

        public LedRestClient(string url, string port, int ledCount)
        {
            _URLWithPort = $"http://{url}:{port}";
            _HttpClient = new RestClient(_URLWithPort);
            _Buffer = RainbowUtils.createEmptyArray(ledCount);
        }

        public bool Send(MyColor.RGB[] input)
        {
            return SendRGBMessage(CreateMessage(input));
        }

        public bool Send(MyColor.RGB input)
        {
            return SendRGBMessage(CreateMessage(input));
        }

        private RGBMessageDto CreateMessage(MyColor.RGB[] input)
        {
            var message = new RGBMessageDto();
            for (var i = 0; i < _Buffer.Length; i++)
            {
                if (_Buffer[i].CompareTo(input[i]) != 0)
                {
                    _Buffer[i] = input[i];
                    message.Pixels.Add(new RGBData
                        {
                            Channel = 0,
                            Position = i,
                            Red = input[i].Red,
                            Green = input[i].Green,
                            Blue = input[i].Blue
                        });                       
                }
            }
            

            return message;
        }

        private RGBMessageDto CreateMessage(MyColor.RGB input)
        {
            var message = new RGBMessageDto();

            for (var i = 0; i < _Buffer.Length; i++)
            {
                if (_Buffer[i].CompareTo(input) != 0)
                {
                    _Buffer[i] = input;
                    message.Pixels.Add(new RGBData
                    {
                        Channel = 0,
                        Position = i,
                        Red = input.Red,
                        Green = input.Green,
                        Blue = input.Blue
                    });
                }
            }

            return message;
        }

        private bool SendRGBMessage(RGBMessageDto rgbMessage)
        {
            if(rgbMessage == null || rgbMessage.Pixels.Count == 0)
            {
                return false;
            }

            var success = false;
            var message = JsonConvert.SerializeObject(rgbMessage);
            var request = new RestRequest("/Rainbow", Method.POST);
            request.AddParameter("application/json; charset=utf-8", message, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            try
            {
                var response = _HttpClient.Execute(request);
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    success = true;
                }
            }
            catch (Exception error)
            {
                // Log
            }
            return success;
        }
    }
}
