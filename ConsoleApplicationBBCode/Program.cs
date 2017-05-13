using C.CodeFormatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplicationBBCode
{
    class Program
    {
        static void Main(string[] args)
        {   
            string str = "[size=5][align=left][size=3][color=#000000][font=Times New Roman]                                 [/font]书香故[/color][/size][/align][align=left][size=3][color=#000000][font=Times New Roman]               [/font]——记浙江省卫生计生委青年“天使情怀·我的读书故事”演讲比赛[/color][/size][/align][align=left][size=3][color=#000000]自古以来，书就被奉为瑰宝，“书中自有千钟粟，书中自有黄金屋，书中自有颜如玉”。理所当然，“读书”甚被鸿儒博贤所推崇，“万般皆下品，惟有读书高”。[/color][/size][/align][align=left][size=3][color=#000000]三毛说，读书多了，容颜自然改变；曾国籓吟，唯读书可以变其气质；梁晓声言，读书是一种抵抗寂寞的能力；林语堂道，读书的意义是使人虚心，较通达，不固陋，不偏执……读书有万般好处，过滤思想，修炼素养，培植智慧，缔造美德。[/color][/size][/align][align=left][size=3][color=#000000]为丰富浙江省卫生计生委系统青年的精神内涵，提升工作品质，增强文化建设，[font=Times New Roman]2014[/font]年[font=Times New Roman]5[/font]月[font=Times New Roman]14[/font]日，浙江省卫生厅特举办“天使情怀·我的读书故事”演讲比赛，并在浙江省卫生监督所如火如荼地开展。[/color][/size][/align][align=left][size=3][color=#000000]此次演讲比赛，聚集了来自委系统各大单位的[font=Times New Roman]28[/font]名青年才俊，互相交流学习，彼此切磋长进。其中，我院共派出了三名青年职工参与比赛，由团委书记赵元元率队征战，她们分别是院工会刘姝佟，康复科陈小根，输液室周蓓蕾。[/color][/size][/align][align=left][size=3][color=#000000]比赛在主持人畅快明朗的开场白后拉开帷幕，隆重介绍了莅临比赛现场的领导嘉宾和评委老师后，省卫生监督所所长叶全富作了激情洋溢的致辞，紧接着选手们按抽签的次序依次登场。[/color][/size][/align][align=left][size=3][color=#000000]比赛过程可谓是精彩纷呈，惊喜不断。有的聘婷秀雅顾盼流转，有的婀娜蹁跹婉约如歌，有的慷慨激昂火花迸射，有的深沉浑厚蕴气满腹……充裕的安静中张扬，肆情的狂热里镇定，娇花照水故艳，细柳拂风亦强。没有一个是输家！[/color][/size][/align][align=left][size=3][color=#000000]讲是一门本事，演是一门学问。选手们把读书和演讲结合地恰到好处，声情并茂，抑扬顿挫，将故事绘成画，把感知谱成曲，书中的精髓被诠释地淋漓尽致。[/color][/size][/align][align=left][size=3][color=#000000]这是一场视觉和听觉的饕餮盛宴。皎若旭日升朝霞，灼若芙蕖出绿波，确是美撼凡尘，书濡肺腑。[/color][/size][/align][align=left][size=3][color=#000000]担任此次比赛的评委团，他们以独特的视角，站在公正的立场上给现场所有参赛选手打出了慎重宝贵的分数。[/color][/size][/align][align=left][size=3][color=#000000]经过紧张激烈的比拼，最终[font=Times New Roman]15[/font]位选手脱颖而出，艳冠群芳。值得庆祝的是，我院的陈小根和周蓓蕾以正常水平的发挥双双夺得二等奖。[/color][/size][/align][align=left][size=3][color=#000000]比赛尾声，省卫计委团委副书记王雷对选手们取得的优异成绩表示热烈祝贺，并针对此次比赛选手的表现作了精辟入里的点评，高度肯定了选手们的超群水平和卓越能力，同时也就其中的不足提了几点珍贵中肯的建议，最后寄予了委系统青年殷切的希望和美好的祝愿。[/color][/size][/align][align=left][size=3][color=#000000]颁奖典礼上，领导们亲切地同获奖选手们合影留念，场面温馨动人。[/color][/size][/align][align=left][size=3][color=#000000]现贵州大学校长，郑强教授曾在浙大学府演讲时发人深省说，读书是为了承担责任。的确，在医患关系日益紧张的医疗环境下，我们应该少点埋怨，多点实干，少点怒斥，多点坚守。用知识武装强大的内心世界，用知识捍卫缺损的人格尊严，用知识抵御无知的愚昧妄拙，用知识拯救扭曲的物质社会。[/color][/size][/align][align=left][size=3][color=#000000]因书明理，以慈怀道，拒抗利诱，触摸良知，我们应在艰苦卑微的岗位中持守医护工作者该有的信仰：宽仁，文明，寡淡，通悟，敬畏，感恩！[/color][/size][/align][align=left][size=3][color=#000000]读书，就是一件把时间花在美好的事上的事！它能把繁琐辛酸的日子过成诗，精致、简单而快乐！[/color][/size][/align][align=left][size=3][color=#000000]摘一朵来自天堂的璀璨，斑斑渍渍间透出生命的美丽，书香故！[/color][/size][/align][align=left][font=Times New Roman][size=3][color=#000000]                                                                 [/color][/size][/font][/align][align=left][font=Times New Roman][size=3][color=#000000]                                                                  2014.05.14[/color][/size][/font][/align][align=left][size=3][color=#000000][font=Times New Roman]                                                               康复科:陈小根[/font][/color][/size][/align][/size]";
            Console.WriteLine(str);
            
            Console.WriteLine("============================");
            ITextFormatter container2 = new BBCodeFormatterContainer();
            string str3 = container2.Format(str);
            Console.WriteLine(str3);

            Console.Read();
        }
    }
}
