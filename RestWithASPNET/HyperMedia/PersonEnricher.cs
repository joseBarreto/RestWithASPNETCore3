﻿using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tapioca.HATEOAS;

namespace RestWithASPNET.HyperMedia
{
    public class PersonEnricher : ObjectContentResponseEnricher<PersonVO>
    {
        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            var path = "http://localhost:52098";
            var url = new { controller = "api/v1/persons", id = content.Id };
            string heref;
            var rel = RelationType.self;

            try
            {
                //heref = urlHelper.Link("DefaultApi", url);
                heref = $@"{path}/{url.controller}/{url.id}";
            }
            catch
            {
                heref = $@"{path}/{url.controller}/{url.id}";
            }

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = heref,
                Rel = rel,
                Type = ResponseTypeFormat.DefaultGet

            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = heref,
                Rel = rel,
                Type = ResponseTypeFormat.DefaultPost
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = heref,
                Rel = rel,
                Type = ResponseTypeFormat.DefaultPost

            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = heref,
                Rel = rel,
                Type = "int"
            });

            return null;
        }
    }
}
