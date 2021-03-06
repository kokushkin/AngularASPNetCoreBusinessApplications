﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace TourManagement.API.Helpers
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public class RequestHeaderMatchesMediaTypeAttribute : Attribute, IActionConstraint
    {
        private readonly string[] _mediaTypes;
        private readonly string _requestHeaderToMatch;

        public RequestHeaderMatchesMediaTypeAttribute(string requestHeaderToMatch, 
            string[] mediaTypes)
        {
            _mediaTypes = mediaTypes;
            _requestHeaderToMatch = requestHeaderToMatch;
        }

        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            var requestHeaders = context.RouteContext.HttpContext.Request.Headers;

            if (!requestHeaders.ContainsKey(_requestHeaderToMatch))
                return false;

            //if on of the media types matches, return true
            foreach (var mediaType in _mediaTypes)
            {
                var headerValues = requestHeaders[_requestHeaderToMatch]
                    .ToString().Split(',').ToList();
                foreach (var headerValue in headerValues)
                {
                    if (string.Equals(headerValue, mediaType,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;

        }
    }
}
