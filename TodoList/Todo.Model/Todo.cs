using Castle.ActiveRecord;

namespace Todo.Model
{
    [ActiveRecord(Table = "todo")]
    public class Todo : ActiveRecordValidationBase<Todo>
    {
        [PrimaryKey(Column = "Id")]
        public virtual int Id { get; set; }

        [Property(Column = "Name", NotNull = true)]
        public virtual string Name { get; set; }

        [Property(Column = "Done", NotNull = true)]
        public virtual string Done { get; set; }
    }
}
