using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;
using BinancePayDotnetSdk.Common.Converters;
using BinancePayDotnetSdk.Common.Enums;

namespace BinancePayDotnetSdk.Common.Forms
{
    /// <summary>
    /// https://developers.binance.com/docs/binance-pay/api-submerchant-add#request-parameters
    /// </summary>
    public class CreateSubMerchantRequestForm : ApiRequestForm
    {
        /// <summary>
        /// The partner merchant id, issued when partner merchant been created at Binance.
        /// </summary>
        [Required]
        [JsonPropertyName("mainMerchantId")] 
        [JsonConverter(typeof(JsonStringLongConverter))]
        public long MainMerchantId { get; set; }
        
        /// <summary>
        /// Unique under one mainMerchantId.
        /// </summary>
        [Required]
        [MaxLength(64)]
        [JsonPropertyName("merchantName")]
        public string MerchantName { get; set; }
        
        [Required]
        [JsonPropertyName("merchantType")]
        [JsonConverter(typeof(JsonEnumIntConverter<MerchantType>))]
        public MerchantType MerchantType { get; set; }
        
        /// <summary>
        /// MCC Code, get from Binance.
        /// </summary>
        [Required]
        [JsonPropertyName("merchantMcc")]
        public string MerchantMcc { get; set; }
        
        /// <summary>
        /// Sub merchant logo url.
        /// </summary>
        [MaxLength(256)]
        [JsonPropertyName("brandLogo")]
        public string BrandLogoUrl { get; set; }
        
        /// <summary>
        /// Country/Region of Business Operation. Can be multiple.".
        /// </summary>
        [Required]
        [JsonPropertyName("country")]
        [JsonConverter(typeof(JsonIsoAlphaTwoArrayRegionInfoConverter))]
        public RegionInfo[] OperationCountries { get; set; }
        
        /// <summary>
        /// Store address.
        /// </summary>
        [MaxLength(1024)]
        [JsonPropertyName("address")] 
        public string Address { get; set; }

        /// <summary>
        /// The legal name that is used in the registration, Required if merchantType is not Individual.
        /// </summary>
        [MaxLength(64)]
        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; } = null;

        /// <summary>
        /// Registration number/Company tax ID, Required if merchantType is not Individual.
        /// </summary>
        [MaxLength(64)]
        [JsonPropertyName("registrationNumber")]
        public string RegistrationNumber { get; set; } = null;

        /// <summary>
        /// Country of Registration, Required if merchantType is not Individual.
        /// </summary>
        [JsonPropertyName("registrationCountry")]
        [JsonConverter(typeof(JsonIsoAlphaTwoRegionInfoConverter))]
        public RegionInfo RegistrationCountry { get; set; } = null;

        /// <summary>
        /// Country of Registration, Required if merchantType is not Individual.
        /// </summary>
        [MaxLength(1024)]
        [JsonPropertyName("registrationAddress")]
        public string RegistrationAddress { get; set; } = null;

        /// <summary>
        /// The date when the business registration is in effective, Required if merchantType is not Individual.
        /// UnixTimestamp in milliseconds.
        /// </summary>
        [JsonPropertyName("incorporationDate")]
        [JsonConverter(typeof(JsonMillisecondsDateTimeOffsetConverter))]
        public DateTimeOffset? IncorporationDate { get; set; } = null;
        
        [JsonPropertyName("storeType")]
        [JsonConverter(typeof(JsonEnumIntConverter<StoreType>))]
        public StoreType StoreType { get; set; }

        /// <summary>
        /// Required if merchantType is not Individual.
        /// </summary>
        [JsonPropertyName("siteType")]
        [JsonConverter(typeof(JsonEnumIntConverter<SiteType?>))]
        public SiteType? SiteType { get; set; } = null;

        /// <summary>
        /// The URL of the website, Required if siteType is Web.
        /// </summary>
        [MaxLength(256)]
        [JsonPropertyName("siteUrl")]
        public string SiteUrl { get; set; } = null;

        [MaxLength(32)]
        [JsonPropertyName("siteName")]
        public string SiteName { get; set; } = null;

        /// <summary>
        /// Required if merchantType is Individual.
        /// </summary>
        [JsonPropertyName("certificateType")]
        [JsonConverter(typeof(JsonEnumIntConverter<CertificateType?>))]
        public CertificateType? CertificateType { get; set; } = null;

        /// <summary>
        /// Required if merchantType is Individual.
        /// </summary>
        [JsonPropertyName("certificateCountry")]
        [JsonConverter(typeof(JsonIsoAlphaTwoRegionInfoConverter))]
        public RegionInfo CertificateCountry { get; set; } = null;

        /// <summary>
        /// Required if merchantType is Individual.
        /// </summary>
        [MaxLength(64)]
        [JsonPropertyName("certificateNumber")]
        public string CertificateNumber { get; set; } = null;

        /// <summary>
        /// Certificate Valid Date, Required if merchantType is Individual.
        /// </summary>
        [JsonPropertyName("certificateValidDate")]
        [JsonConverter(typeof(JsonMillisecondsDateTimeOffsetConverter))]
        public DateTimeOffset? CertificateValidDate { get; set; } = null;
        
        /// <summary>
        /// Contract date with ISV.
        /// </summary>
        [JsonPropertyName("contractTimeIsv")]
        [JsonConverter(typeof(JsonMillisecondsDateTimeOffsetConverter))]
        public DateTimeOffset ContractTimeIsv { get; set; }
    }
}