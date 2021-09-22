using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BinancePayDotnetSdk.Common.Converters;
using BinancePayDotnetSdk.Common.Enums;

namespace BinancePayDotnetSdk.Common.Forms
{
    /// <summary>
    /// https://developers.binance.com/docs/binance-pay/api-submerchant-add#request-parameters
    /// </summary>
    public class CreateSubMerchantRequestForm
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
        /// Iso alpha 2 country code (https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2), use "GO" if global.
        /// Country/Region of Business Operation,Can be multiple, split by "," eg:"SG,US".
        /// </summary>
        [Required]
        [JsonPropertyName("country")]
        public string CountryCode  { get; set; }
        
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
        public string CompanyName { get; set; }
        
        /// <summary>
        /// Registration number/Company tax ID, Required if merchantType is not Individual.
        /// </summary>
        [MaxLength(64)]
        [JsonPropertyName("registrationNumber")]
        public string RegistrationNumber { get; set; }
        
        /// <summary>
        /// Country of Registration, Required if merchantType is not Individual.
        /// Iso alpha 2 country code (https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2), use "GO" if global.
        /// </summary>
        [JsonPropertyName("registrationCountry")]
        public string RegistrationCountry { get; set; }
        
        /// <summary>
        /// Country of Registration, Required if merchantType is not Individual.
        /// </summary>
        [MaxLength(1024)]
        [JsonPropertyName("registrationAddress")]
        public string RegistrationAddress { get; set; }
        
        /// <summary>
        /// The date when the business registration is in effective, Required if merchantType is not Individual.
        /// UnixTimestamp in milliseconds.
        /// </summary>
        [JsonPropertyName("incorporationDate")]
        [JsonConverter(typeof(JsonMillisecondsDateTimeOffsetConverter))]
        public DateTimeOffset IncorporationDate { get; set; }
        
        [JsonPropertyName("storeType")]
        [JsonConverter(typeof(JsonEnumIntConverter<StoreType>))]
        public StoreType StoreType { get; set; }
        
        /// <summary>
        /// Required if merchantType is not Individual.
        /// </summary>
        [JsonPropertyName("siteType")]
        [JsonConverter(typeof(JsonEnumIntConverter<SiteType>))]
        public SiteType SiteType { get; set; }
        
        /// <summary>
        /// The URL of the website, Required if siteType is Web.
        /// </summary>
        [MaxLength(256)]
        [JsonPropertyName("siteUrl")]
        public string SiteUrl { get; set; }
        
        [MaxLength(32)]
        [JsonPropertyName("siteName")]
        public string SiteName { get; set; }
        
        /// <summary>
        /// Required if merchantType is Individual.
        /// </summary>
        [JsonPropertyName("certificateType")]
        [JsonConverter(typeof(JsonEnumIntConverter<CertificateType>))]
        public CertificateType CertificateType { get; set; }

        /// <summary>
        /// Iso alpha 2 country code (https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2).
        /// Required if merchantType is Individual.
        /// </summary>
        [JsonPropertyName("certificateCountry")]
        public string CertificateCountry { get; set; }
        
        /// <summary>
        /// Required if merchantType is Individual.
        /// </summary>
        [MaxLength(64)]
        [JsonPropertyName("certificateNumber")]
        public string CertificateNumber { get; set; }

        /// <summary>
        /// Certificate Valid Date, Required if merchantType is Individual.
        /// </summary>
        [JsonPropertyName("certificateValidDate")]
        [JsonConverter(typeof(JsonMillisecondsDateTimeOffsetConverter))]
        public DateTimeOffset CertificateValidDate { get; set; }
        
        /// <summary>
        /// Contract date with ISV.
        /// </summary>
        [JsonPropertyName("contractTimeIsv")]
        [JsonConverter(typeof(JsonMillisecondsDateTimeOffsetConverter))]
        public DateTimeOffset ContractTimeIsv { get; set; }
    }
}