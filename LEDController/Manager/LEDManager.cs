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

        private DRColor.RGB[] _Buffer { get; set; }

        public int _LEDCount { get; }

        private int _ChannelSegment = 60;

        public LEDManager(string url, string port, int ledCount)
        {
            _URLWithPort = $"http://{url}:{port}";
            _HttpClient = new RestClient(_URLWithPort);
            _LEDCount = ledCount;
            _Buffer = RainbowUtils.createEmptyArray(ledCount);
        }

        public RGBMessageDto CreateMessage(DRColor.RGB[] input)
        {
            var message = new RGBMessageDto();
            for (var c = 0; c < 2; c++)
            {
                for (var i = 0; i < _LEDCount; i++)
                {
                    if (_Buffer[i].different(input[i]))
                    {
                        _Buffer[i] = input[i];
                        message.pixels.Add(new RGBData
                            {
                                channel = c,
                                position = i,
                                red = input[i].Red,
                                green = input[i].Green,
                                blue = input[i].Blue
                            });                       
                    }
                }
            }

            return message;
        }

        public RGBMessageDto CreateMessage(DRColor.RGB input)
        {
            var message = new RGBMessageDto();

            for (var i = 0; i < _LEDCount; i++)
            {
                if (_Buffer[i].different(input))
                {
                    _Buffer[i] = input;
                    message.pixels.Add(new RGBData
                    {
                        channel = i < _ChannelSegment ? 1 : 2,
                        position = i,
                        red = input.Red,
                        green = input.Green,
                        blue = input.Blue
                    });
                }
            }

            return message;
        }

        public bool SendRGBMessage(RGBMessageDto rgbMessage)
        {
            if(rgbMessage.pixels.Count == 0)
            {
                return true;
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
