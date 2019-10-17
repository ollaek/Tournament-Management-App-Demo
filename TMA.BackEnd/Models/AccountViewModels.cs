using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TMA.BackEnd.Models
{
    // Models returned by AccountController actions.
    public class FacebookUserViewModel
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }

    }
    
    public class RegisterExternalBindingModel3
    {
        [Display(Name = "Photo")]
        public string Photo { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
        [Phone]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Display(Name = "CountryCode")]
        public string CountryCode { get; set; }
        public string Token { get; set; }


    }
    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }

    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
