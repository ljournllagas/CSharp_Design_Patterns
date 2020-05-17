using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement()
        {

        }

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.Append($"{i}<{Name}>\n");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.Append(Text);
                sb.Append("\n");
            }

            foreach (var e in Elements)
                sb.Append(e.ToStringImpl(indent + 1));

            sb.Append($"{i}</{Name}>\n");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    class HtmlBuilder
    {
        private readonly string rootName;

        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        // not fluent
        public void AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
        }

        public HtmlBuilder AddChildFluent(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement { Name = rootName };
        }

    }

    class BasicBuilderPattern
    {
        //static void Main(string[] args)
        //{
        //    var sb = new StringBuilder();

        //    #region Life Without the Builder Pattern
        //    var hello = "hello";

        //    sb.Append("<p>");
        //    sb.Append(hello);
        //    sb.Append("</p>");
        //    Console.WriteLine(sb);

        //    var words = new[] { "hello", "world" };
        //    sb.Clear();
        //    sb.Append("<ul>");
        //    foreach (var word in words)
        //    {
        //        sb.AppendFormat("<li>{0}</li>", word);
        //    }
        //    sb.Append("</ul>");
        //    Console.WriteLine(sb);
        //    #endregion

        //    #region Builder Pattern
        //    // ordinary non-fluent builder
        //    var builder = new HtmlBuilder("ul");
        //    builder.AddChild("li", "hello");
        //    builder.AddChild("li", "world");
        //    Console.WriteLine(builder.ToString());
        //    #endregion

        //    #region Builder Pattern with Fluent
        //    // fluent builder
        //    sb.Clear();
        //    builder.Clear(); // disengage builder from the object it's building, then...
        //    builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
        //    Console.WriteLine(builder);
        //    #endregion
        //}
    }
}
