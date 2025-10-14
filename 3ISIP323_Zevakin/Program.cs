using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

public class person
{
    private static int ids;
    private int id { get;set }
    private int phone{ get;set }
    private string name{ get;set }
    
}
public class prepod:person
{
    private static int ids;
    private int experience { get;set }

    public prepod(int experience,int phone, string name):base(id,phone,name)
    {
        ids += 1;
        this.id = ids;
        this.name = name;

    }

}
public class student : person
{
    private static int ids;
    private int group { get; set }
    private List<university_course> course { get; set }

    public prepod(int group,int course,int phone,string name) : base(id, phone, name)
    {
        ids += 1;
        this.id = ids;
        this.name_pr = name_pr;
        this.group_num = group_num;

    }

}
public class university_course
{
    private static int ids;
    private int id;
    private string name_cour { get;set }
    private string time { get;set }
    private prepod prepod { get;set }
    public university_course()

}