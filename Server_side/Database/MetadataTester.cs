// Copyright © 2012-2018 Alex Kukhtin. All rights reserved.


using NUnit.Framework;
using A2v10.Data;
using A2v10.Data.Interfaces;

namespace Server_side.Database
{
    public class MetadataTester
    {
        public IDictionary<String, IDataMetadata> _meta;

        public MetadataTester(IDataModel dataModel)
        {
            _meta = dataModel.Metadata as IDictionary<String, IDataMetadata>;
            Assert.That(_meta, Is.Not.Null);
        }

        public void IsAllKeys(String props)
        {
            var propArray = props.Split(',');
            foreach (var prop in propArray)
                Assert.That(_meta.ContainsKey(prop.Trim()), Is.True, $"'{prop}' not found");
            Assert.That(_meta.Count, Is.EqualTo(propArray.Length), $"invalid length for '{props}'");
        }

        public void HasAllProperties(String key, String props)
        {
            var data = _meta[key] as ElementMetadata;
            var propArray = props.Split(',');
            foreach (var prop in propArray)
                Assert.That(data.ContainsField(prop.Trim()), Is.True, $"'{prop}' not found");
            Assert.That(data.FieldCount, Is.EqualTo(propArray.Length), $"invalid length for '{props}' properties");
        }

        public void IsId(String key, String prop)
        {
            var data = _meta[key] as ElementMetadata;
            Assert.That(prop, Is.EqualTo(data.Id));
        }

        public void IsKey(String key, String prop)
        {
            var data = _meta[key] as ElementMetadata;
            Assert.That(prop, Is.EqualTo(data.Key));
        }

        public void IsName(String key, String prop)
        {
            var data = _meta[key] as ElementMetadata;
            Assert.That(prop, Is.EqualTo(data.Name));
        }

        public void IsType(String key, String propName, DataType dt)
        {
            var data = _meta[key] as ElementMetadata;
            Assert.That(data.ContainsField(propName), Is.True);
            var fp = data.GetField(propName);
            Assert.That(dt, Is.EqualTo(fp.DataType));
        }

        public void IsItems(String key, String prop)
        {
            var data = _meta[key] as ElementMetadata;
            Assert.That(prop, Is.EqualTo(data.Items));
        }

        public void IsItemType(String key, String propName, FieldType ft)
        {
            var data = _meta[key] as ElementMetadata;
            Assert.That(data.ContainsField(propName), Is.True, $"Invalid item type for {key}.{propName}");
            var fp = data.GetField(propName);
            Assert.That(ft, Is.EqualTo(fp.ItemType));
        }

        public void IsItemRefObject(String key, String propName, String refObject, FieldType ft)
        {
            var data = _meta[key] as ElementMetadata;
            Assert.That(data.ContainsField(propName), Is.True);
            var fp = data.GetField(propName);
            Assert.That(refObject, Is.EqualTo(fp.RefObject));
            Assert.That(ft, Is.EqualTo(fp.ItemType));
        }

        public void IsItemIsArrayLike(String key, String propName)
        {
            var data = _meta[key] as ElementMetadata;
            Assert.That(data.ContainsField(propName), Is.True);
            var fp = data.GetField(propName);
            Assert.That(fp.IsArrayLike, Is.True);
        }
    }

}