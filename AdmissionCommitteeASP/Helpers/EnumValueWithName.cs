using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AdmissionCommitteeASP.Helpers
{
    /// <summary> Структура, содержащая значение и соответствующий ему текст для заполнения <see cref="Microsoft.AspNetCore.Mvc.Rendering.SelectList"/> </summary>
    /// <param name="value">значение enum</param>
    /// <typeparam name="T">тип enum</typeparam>
    public readonly struct EnumValueWithName<T>(T value)
        where T : Enum
    {
        public T Value { get; } = value;
        public string DisplayName { get; } = GetMemberDisplayName(value);

        /// <summary>
        /// Возвращает name атрибута <see cref="DisplayAttribute"/> значения enum, а если его нет, то его строковое представление/>
        /// </summary>
        /// <param name="value">значение типа <see cref="T"/></param>
        private static string GetMemberDisplayName(T value)
        {
            var type = typeof(T);
            var name = Enum.GetName(type, value)!;
            var member = type.GetMember(name).First();
            var attributes = member.GetCustomAttributes(typeof(DisplayAttribute)).Cast<DisplayAttribute>().ToArray();
            foreach (var attribute in attributes)
            {
                if (attribute.Name != null)
                {
                    return attribute.Name;
                }
            }

            return name;
        }
    }
}
