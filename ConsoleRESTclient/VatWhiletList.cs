using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsoleRESTclient
{
	class VatWhiletList
	{
		[JsonPropertyName("result")]
		public VatWhiteListResult Result { get; set; } = new VatWhiteListResult();
	}

	class VatWhiteListResult
	{
		[JsonPropertyName("subject")]
		public ResultSubject resultSubject { get; set; } = new ResultSubject();
	}

	class ResultSubject
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("nip")]
		public string NIP { get; set; }

		[JsonPropertyName("statusVat")]
		public string VATstatus { get; set; }

		[JsonPropertyName("regon")]
		public string REGON { get; set; }

		[JsonPropertyName("workingAddress")]
		public string WorkingAddress { get; set; }
	}
}


/*
result
subject
name	"FIRMA HANDLOWO-USŁUGOWA 'VICTOR' S.C., WIESŁAW ŚLIPEK, DOROTA ŚLIPEK"
nip	"8291490928"
statusVat	"Czynny"
regon	"730365570"
pesel	null
krs	null
residenceAddress	null
workingAddress	"TYMIENICE 42A, 98-220 TYMIENICE"
representatives[]
authorizedClerks[]
partners[]
registrationLegalDate   "1998-03-07"
registrationDenialBasis	null
registrationDenialDate	null
restorationBasis	null
restorationDate	null
removalBasis	null
removalDate	null
accountNumbers	
0	"64124033051111000029376791"
hasVirtualAccounts	false
requestId	"94jjd-87hh832"
requestDateTime	"25-05-2020 23:27:38"
*/



