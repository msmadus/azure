using Newtonsoft.Json;
using System.Collections.Generic;

namespace CDAXIGAIntegration.Models
{
    public class ModifyUserRequest
    {
        [JsonProperty("@odata.context")]
        public string odatacontext { get; set; }
        public Value[] value { get; set; }
    }

    public class Value
    {
        [JsonProperty("@odata.etag")]
        public string odataetag { get; set; }
        public string ownerid { get; set; }
        public string envname { get; set; }
        public string internalemailaddress { get; set; }

        [JsonProperty("_hpi_userprofile_value@OData.Community.Display.V1.FormattedValue")]
        public string _hpi_userprofile_valueODataCommunityDisplayV1FormattedValue { get; set; }
        public string _hpi_userprofile_value { get; set; }

        [JsonProperty("hpi_hpisegment@OData.Community.Display.V1.FormattedValue")]
        public string hpi_hpisegmentODataCommunityDisplayV1FormattedValue { get; set; }
        public int hpi_hpisegment { get; set; }

        [JsonProperty("_businessunitid_value@OData.Community.Display.V1.FormattedValue")]
        public string _businessunitid_valueODataCommunityDisplayV1FormattedValue { get; set; }
        public string _businessunitid_value { get; set; }

        [JsonProperty("hpi_usertimezone@OData.Community.Display.V1.FormattedValue")]
        public string hpi_usertimezoneODataCommunityDisplayV1FormattedValue { get; set; }
        public int hpi_usertimezone { get; set; }

        [JsonProperty("hpi_discountlevel@OData.Community.Display.V1.FormattedValue")]
        public string hpi_discountlevelODataCommunityDisplayV1FormattedValue { get; set; }
        public int hpi_discountlevel { get; set; }

        public string systemuserid { get; set; }

        [JsonProperty("_hpi_userlanguage_value@OData.Community.Display.V1.FormattedValue")]
        public string _hpi_userlanguage_valueODataCommunityDisplayV1FormattedValue { get; set; }
        public string _hpi_userlanguage_value { get; set; }

        [JsonProperty("_hpi_costlocationid_value@OData.Community.Display.V1.FormattedValue")]
        public string _hpi_costlocationid_valueODataCommunityDisplayV1FormattedValue { get; set; }
        public string _hpi_costlocationid_value { get; set; }

        [JsonProperty("_hpi_originatingorgunit_value@OData.Community.Display.V1.FormattedValue")]
        public string _hpi_originatingorgunit_valueODataCommunityDisplayV1FormattedValue { get; set; }
        public string _hpi_originatingorgunit_value { get; set; }

        public string fullname { get; set; }

        [JsonProperty("_hpi_defaultemailprofile_value@OData.Community.Display.V1.FormattedValue")]
        public string _hpi_defaultemailprofile_valueODataCommunityDisplayV1FormattedValue { get; set; }
        public string _hpi_defaultemailprofile_value { get; set; }

        [JsonProperty("_hpi_workgroupid_value@OData.Community.Display.V1.FormattedValue")]
        public string _hpi_workgroupid_valueODataCommunityDisplayV1FormattedValue { get; set; }
        public string _hpi_workgroupid_value { get; set; }

        public Hpi_Systemuser_Hpi_Country[] hpi_systemuser_hpi_country { get; set; }
        [JsonProperty("hpi_systemuser_hpi_country@odata.nextLink")]
        public string hpi_systemuser_hpi_countryodatanextLink { get; set; }

        public Hpi_Systemuser_Hpi_Language[] hpi_systemuser_hpi_language { get; set; }
        [JsonProperty("hpi_systemuser_hpi_language@odata.nextLink")]
        public string hpi_systemuser_hpi_languageodatanextLink { get; set; }

        public Hpi_Systemuser_Hpi_Productline[] hpi_systemuser_hpi_productline { get; set; }
        [JsonProperty("hpi_systemuser_hpi_productline@odata.nextLink")]
        public string hpi_systemuser_hpi_productlineodatanextLink { get; set; }

        public Hpi_Systemuser_Hpi_Region[] hpi_systemuser_hpi_region { get; set; }
        [JsonProperty("hpi_systemuser_hpi_region@odata.nextLink")]
        public string hpi_systemuser_hpi_regionodatanextLink { get; set; }

        public Hpi_Systemuser_Hpi_Supportchannel[] hpi_systemuser_hpi_supportchannel { get; set; }
        [JsonProperty("hpi_systemuser_hpi_supportchannel@odata.nextLink")]
        public string hpi_systemuser_hpi_supportchannelodatanextLink { get; set; }

        public Hpi_Systemuser_Hpi_Supportlevel[] hpi_systemuser_hpi_supportlevel { get; set; }
        [JsonProperty("hpi_systemuser_hpi_supportlevel@odata.nextLink")]
        public string hpi_systemuser_hpi_supportlevelodatanextLink { get; set; }

        public Msdyn_Appconfiguration_Systemuser[] msdyn_appconfiguration_systemuser { get; set; }
        [JsonProperty("msdyn_appconfiguration_systemuser@odata.nextLink")]
        public string msdyn_appconfiguration_systemuserodatanextLink { get; set; }

        public Systemuserprofiles_Association[] systemuserprofiles_association { get; set; }
        [JsonProperty("systemuserprofiles_association@odata.nextLink")]
        public string systemuserprofiles_associationodatanextLink { get; set; }

        public Systemuserroles_Association[] systemuserroles_association { get; set; }
        [JsonProperty("systemuserroles_association@odata.nextLink")]
        public string systemuserroles_associationodatanextLink { get; set; }

        public Teammembership_Association[] teammembership_association { get; set; }
        [JsonProperty("teammembership_association@odata.nextLink")]
        public string teammembership_associationodatanextLink { get; set; }
    }

    public class Hpi_Systemuser_Licenses    {
        public string name { get; set; }
    }

    public class Hpi_Systemuser_Hpi_Country
    {
        public string odataetag { get; set; }
        public string hpi_countryname { get; set; }
        public string hpi_countryid { get; set; }
    }

    public class Hpi_Systemuser_Hpi_Language
    {
        public string odataetag { get; set; }
        public string hpi_languageid { get; set; }
        public string hpi_languagename { get; set; }
    }

    public class Hpi_Systemuser_Hpi_Productline
    {
        public string odataetag { get; set; }
        public string hpi_productlineid { get; set; }
        public string hpi_productlinename { get; set; }
    }

    public class Hpi_Systemuser_Hpi_Region
    {
        public string odataetag { get; set; }
        public string hpi_regionname { get; set; }
        public string hpi_regionid { get; set; }
    }

    public class Hpi_Systemuser_Hpi_Supportchannel
    {
        public string odataetag { get; set; }
        public string hpi_supportchannelid { get; set; }
        public string hpi_name { get; set; }
    }

    public class Hpi_Systemuser_Hpi_Supportlevel
    {
        public string odataetag { get; set; }
        public string hpi_name { get; set; }
        public string hpi_supportlevelid { get; set; }
    }

    public class Msdyn_Appconfiguration_Systemuser
    {
        public string odataetag { get; set; }
        public string msdyn_appconfigurationid { get; set; }
        public string msdyn_name { get; set; }
    }

    public class Systemuserprofiles_Association
    {
        public string odataetag { get; set; }
        public string name { get; set; }
        public string fieldsecurityprofileid { get; set; }
    }

    public class Systemuserroles_Association
    {
        public string odataetag { get; set; }
        public string name { get; set; }
        public string roleid { get; set; }
    }

    public class Teammembership_Association
    {
        public string odataetag { get; set; }
        public string ownerid { get; set; }
        public string name { get; set; }
        public string teamid { get; set; }
    }
}