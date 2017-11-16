﻿/*Version: MPL 1.1/EUPL 1.1
 * 
 * The contents of this file are subject to the Mozilla Public License Version 
 * 1.1 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at:
 * http://www.mozilla.org/MPL/
 * 
 * Software distributed under the License is distributed on an "AS IS" basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the
 * License.
 * 
 * The Original Code is Copyright The PEPPOL project (http://www.peppol.eu)
 * 
 * Alternatively, the contents of this file may be used under the
 * terms of the EUPL, Version 1.1 or - as soon they will be approved 
 * by the European Commission - subsequent versions of the EUPL 
 * (the "Licence"); You may not use this work except in compliance 
 * with the Licence.
 * You may obtain a copy of the Licence at:
 * http://www.osor.eu/eupl/european-union-public-licence-eupl-v.1.1
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the Licence is distributed on an "AS IS" basis,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the Licence for the specific language governing permissions and
 * limitations under the Licence.
 * 
 * If you wish to allow use of your version of this file only
 * under the terms of the EUPL License and not to allow others to use
 * your version of this file under the MPL, indicate your decision by
 * deleting the provisions above and replace them with the notice and
 * other provisions required by the EUPL License. If you do not delete
 * thev provisions above, a recipient may use your version of this file
 * under either the MPL or the EUPL License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Web;
using STARTLibrary.src.eu.peppol.start.xml.request;
using STARTLibrary.src.eu.peppol.start.xml.structure;

namespace STARTLibrary.src.eu.peppol.start.xml.parser
{
    public class SignedServiceParser
    {
        /// <summary>
        /// Store SignedService objects
        /// </summary>
        /// <param name="smpSignedServiceUrl"></param>
        /// <returns>Stored SignedService object ready for deserialization</returns>
        public SignedServiceMetadata GetSignedService(string smpSignedServiceUrl)
        {
            StartRequest _startRequest = new StartRequest();

            try
            {
                string signedServiceContent = _startRequest.GetContent(smpSignedServiceUrl).Replace("ns3:SignedServiceMetadataType", "ns3:SignedServiceMetadata");
                StringReader stringReader = new StringReader(signedServiceContent);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(SignedServiceMetadata));
                return (SignedServiceMetadata)xmlSerializer.Deserialize(stringReader);
            }
            catch (Exception)
            { return null; }
        }
    }
}