using ChoppSoft.Infra.Bases.Enums;

namespace ChoppSoft.Infra.Bases
{
    public class Filter
    {
        public string PropertyName { get; set; }
        public EnumOperationType Operation { get; set; }
        public string Value { get; set; }
        public string AdditionalValue { get; set; }
    }
}
