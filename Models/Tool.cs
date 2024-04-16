namespace PowerTools.Models
{
    public class Tool
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string LinktoImage { get; set; }
        public string FirstSpecs { get; set; }
        public string SecondSpecs { get; set; }
        public string ThirdSpecs { get; set; }
        public string FourthSpecs { get; set; }
        public string FifthSpecs { get; set; }
        public string SixthSpecs { get; set; }
        public string SecondTitle {  get; set; }
        public string FirstSlide { get; set; }
        public string SecondSlide { get; set; }
        public string ThirdSlide { get; set; }
        public string FourthSlide { get; set; }

        // Вариант 2: Конструктор с параметрами, соответствующими свойствам
        public Tool(int ID, string Name, string Title, string LinktoImage, string FirstSpecs, string SecondSpecs, string ThirdSpecs, string FourthSpecs, string FifthSpecs, string SixthSpecs, string SecondTitle, string FirstSlide, string SecondSlide, string ThirdSlide, string FourthSlide)
        {
            this.ID = ID;
            this.Name = Name;
            this.Title = Title;
            this.LinktoImage = LinktoImage;
            this.FirstSpecs = FirstSpecs;
            this.SecondSpecs = SecondSpecs;
            this.ThirdSpecs = ThirdSpecs;
            this.FourthSpecs = FourthSpecs;
            this.FifthSpecs = FifthSpecs;
            this.SixthSpecs = SixthSpecs;
            this.SecondTitle = SecondTitle;
            this.FirstSlide = FirstSlide;
            this.SecondSlide = SecondSlide;
            this.ThirdSlide = ThirdSlide;
            this.FourthSlide = FourthSlide;
        }
    }
}
