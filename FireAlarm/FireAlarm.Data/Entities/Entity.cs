using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace FireAlarm.Data.Entities
{
    public abstract class Entity<T> where T : struct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public abstract T Id { get; set; }

        public string Table
        {
            get
            {
                var tableAttribute =
                    GetType().GetTypeInfo().GetCustomAttribute(typeof(TableAttribute), true) as TableAttribute;

                if (tableAttribute == null) return string.Empty;

                return tableAttribute.Name;
            }
        }

        public string KeyColumn
        {
            get
            {
                var keyColumn = string.Empty;

                foreach (var property in GetType().GetProperties())
                {
                    var keyAttribute = property.GetCustomAttribute(typeof(KeyAttribute), true) as KeyAttribute;

                    if (keyAttribute != null)
                    {
                        var columnAttribute =
                            property.GetCustomAttribute(typeof(ColumnAttribute), true) as ColumnAttribute;
                        keyColumn = columnAttribute.Name;
                        break;
                    }
                }

                return keyColumn;
            }
        }

        public List<string> Columns
        {
            get
            {
                var columns = new List<string>();

                foreach (var property in GetType().GetProperties())
                {
                    var columnAttribute = property.GetCustomAttribute(typeof(ColumnAttribute), true) as ColumnAttribute;

                    if (columnAttribute == null) continue;

                    columns.Add(columnAttribute.Name);
                }

                return columns;
            }
        }

        public List<string> Values
        {
            get
            {
                var values = new List<string>();

                foreach (var property in GetType().GetProperties())
                {
                    var columnAttribute = property.GetCustomAttribute(typeof(ColumnAttribute), true) as ColumnAttribute;

                    if (columnAttribute == null) continue;

                    if (typeof(DateTime).IsAssignableFrom(property.PropertyType))
                        values.Add($"'{property.GetValue(this)}'");
                    else if (typeof(string).IsAssignableFrom(property.PropertyType))
                        values.Add($"'{property.GetValue(this)}'");
                    else if (typeof(Guid).IsAssignableFrom(property.PropertyType))
                        values.Add($"'{property.GetValue(this)}'");
                    else
                        values.Add($"{property.GetValue(this)}");
                }

                return values;
            }
        }

        public Dictionary<string, string> ColumnsAndValues
        {
            get
            {
                var columnsAndValues = new Dictionary<string, string>();

                foreach (var property in GetType().GetProperties())
                {
                    var columnAttribute = property.GetCustomAttribute(typeof(ColumnAttribute), true) as ColumnAttribute;

                    if (columnAttribute == null) continue;

                    if (typeof(DateTime).IsAssignableFrom(property.PropertyType))
                        columnsAndValues.Add(columnAttribute.Name, $"'{property.GetValue(this)}'");
                    else if (typeof(string).IsAssignableFrom(property.PropertyType))
                        columnsAndValues.Add(columnAttribute.Name, $"'{property.GetValue(this)}'");
                    else if (typeof(Guid).IsAssignableFrom(property.PropertyType))
                        columnsAndValues.Add(columnAttribute.Name, $"'{property.GetValue(this)}'");
                    else
                        columnsAndValues.Add(columnAttribute.Name, $"{property.GetValue(this)}");
                }

                return columnsAndValues;
            }
        }

        public string InsertSql =>
            $"INSERT INTO {Table} ({string.Join(", ", Columns)}) VALUES ({string.Join(", ", Values)})";

        public string UpdateSql
        {
            get
            {
                var columnsAndValues = ColumnsAndValues.Select(kvp => string.Format(@"{0}={1}", kvp.Key, kvp.Value));
                return $"UPDATE {Table} SET {string.Join(", ", columnsAndValues)} WHERE {KeyColumn} = {Id}";
            }
        }

        public string DeleteSql => $"DELETE FROM {Table} WHERE {KeyColumn} = {Id}";

        public string SequenceName => $"{Table}_{KeyColumn}_seq";
    }
}