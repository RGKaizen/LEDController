using LEDController.Dtos;
using LEDController.Interfaces;
using LEDController.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace LEDController.Manager
{
    public class LEDManager : ILEDManager
    {
        private RestClient _HttpClient { get; set; }

        private string _URLWithPort { get; set; }

        private MyColor.RGB[] _Buffer { get; set; }

        public int TotalLEDCount { get; }

        public int LEDStripLength { get; } = 60 ;

        public LEDManager(string url, string port, int ledCount)
        {
            _URLWithPort = $"http://{url}:{port}";
            _HttpClient = new RestClient(_URLWithPort);
            TotalLEDCount = ledCount;
            _Buffer = RainbowUtils.createEmptyArray(ledCount);
        }

        public RGBMessageDto CreateMessage(MyColor.RGB[] input)
        {
            var message = new RGBMessageDto();
            for (var i = 0; i < TotalLEDCount; i++)
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

        public RGBMessageDto CreateMessage(MyColor.RGB input)
        {
            var message = new RGBMessageDto();

            for (var i = 0; i < TotalLEDCount; i++)
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

        public bool SendRGBMessage(RGBMessageDto rgbMessage)
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
