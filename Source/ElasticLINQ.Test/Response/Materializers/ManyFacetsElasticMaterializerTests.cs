﻿using System;
using ElasticLinq.Response.Materializers;
using ElasticLinq.Response.Model;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Xunit;

namespace ElasticLinq.Test.Response.Materializers
{
    public class ManyFacetsElasticMaterializerTests
    {
        [Fact]
        public void MaterializeThrowsArgumentNullExceptionWhenElasticResponseIsNull()
        {
            var materializer = new ManyFacetsElasticMaterializer(r => r, typeof(SampleClass), typeof(string));

            Assert.Throws<ArgumentNullException>(() => materializer.Materialize(null));
        }

        [Fact]
        public void MaterializeWithNullFacetsReturnsBlankList()
        {
            var materializer = new ManyFacetsElasticMaterializer(r => r, typeof(object), typeof(string));
            var response = new ElasticResponse { facets = null };

            var actual = materializer.Materialize(response);

            var actualList = Assert.IsType<List<object>>(actual);
            Assert.Empty(actualList);
        }

        [Fact]
        public void MaterializeWithNoFacetsReturnsBlankList()
        {
            var materializer = new ManyFacetsElasticMaterializer(r => r, typeof(SampleClass), typeof(string));
            var response = new ElasticResponse { facets = new JObject() };

            var actual = materializer.Materialize(response);

            var actualList = Assert.IsType<List<SampleClass>>(actual);
            Assert.Empty(actualList);
        }
    }
}