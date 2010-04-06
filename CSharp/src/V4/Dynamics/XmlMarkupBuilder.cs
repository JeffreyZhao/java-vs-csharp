using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Xml.Linq;

namespace V4.Dynamics
{
    public class XmlMarkupBuilder : DynamicObject
    {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            XElement xml = new XElement(binder.Name);

            var attrCount = binder.CallInfo.ArgumentNames.Count;
            var elementCount = args.Length - attrCount;

            for (int i = 0; i < elementCount; i++)
            {
                xml.Add(args[i]);
            }

            for (var i = 0; i < attrCount; i++)
            {
                var attrName = binder.CallInfo.ArgumentNames[i];
                if (attrName[0] == '@') attrName = attrName.Substring(1);

                xml.Add(new XAttribute(attrName, args[i + elementCount]));
            }

            result = xml;
            return true;
        }
    }
}
