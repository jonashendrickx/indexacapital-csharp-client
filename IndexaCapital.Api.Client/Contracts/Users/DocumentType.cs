using System.Runtime.Serialization;

namespace IndexaCapital.Api.Client.Contracts.Users
{
    public enum DocumentType
    {
        [EnumMember(Value = "nif")]
        NIF,

        [EnumMember(Value = "cif")]
        CIF,

        [EnumMember(Value = "pass")]
        Pass,

        [EnumMember(Value = "nie")]
        NIE,

        [EnumMember(Value = "doc_ext")]
        DocExt,
        
        [EnumMember(Value = "cif_no_r")]
        CIFNoR,

        [EnumMember(Value = "nif_no_r")]
        NIFNoR,

        [EnumMember(Value = "nif_meno")]
        NIFMeno
    }
}
