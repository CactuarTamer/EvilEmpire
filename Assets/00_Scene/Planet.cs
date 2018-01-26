using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{

    public int Population;
    public double Money;
    public double Tech;
    public double Manga;
    public double Food;
    public int size;
    public int Morale;
    public int Supporter;
    public int Opposition;
    public int neutral;
    public int ResistantBW;
    public double Regen_Money;
    public double Regen_Tech;
    public double Regen_Manga;
    public double Regen_Food;
    public double Max_Money;
    public double Max_Tech;
    public double Max_Manga;
    public double Max_Food;
    public int HiddenProperty;
    public int resistances;
    public double Signal_Str;

    private double op_mod = 0.4;
    private double sup_mod = 1;
    private double Support_turn = 0;
    private double Oppos_turn = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Calculate_turning();
        Regen_res();
        //Calculate_morale();

        ////////////// turning calculate
        int Oturning = (int)Oppos_turn;
        int Sturning = (int)Support_turn;
        if (neutral > 0)
        {

            Calculate_population(-(Oturning));
            Calculate_population(Sturning);

            Oppos_turn -= Oturning;
            Support_turn -= Sturning;


        }
        else
        {
            double sum = Support_turn - Oppos_turn;

            if (!(sum < 1 && sum > -1))
            {

                Calculate_population((int)sum);


                if (sum > 1)
                {
                    Oppos_turn = 0;
                    Support_turn -= Sturning;
                }
                else
                {
                    Support_turn = 0;
                    Oppos_turn -= Oturning;

                }


            }
        }
        ////////////////////////////////////////


        //other code here
    }

    void Regen_res()
    {
        Money += Regen_Money * Time.deltaTime;
        Manga += Regen_Manga * Time.deltaTime;
        Tech += Regen_Tech * Time.deltaTime;
        Food += Regen_Food * Time.deltaTime;

        if (Money > Max_Money)
            Money = Max_Money;

        if (Manga > Max_Manga)
            Manga = Max_Manga;

        if (Tech > Max_Tech)
            Tech = Max_Tech;

        if (Food > Max_Food)
            Food = Max_Food;
    }

    void Calculate_turning()
    {
        //calculate function here (if we gonna use model it here)
        Oppos_turn += (Opposition * op_mod + 1000000) * Time.deltaTime;
        Support_turn += (Supporter * sup_mod /*+ 0.001 * Population * 1*/  ) * Time.deltaTime;
    }

    void Calculate_population(int x)
    {
        if (x > 0)
        {
            Supporter += x;

            if (Supporter > Population)
                Supporter = Population;


            if (x < neutral)
            {
                neutral -= x;
            }

            else
            {
                Opposition = Population - Supporter;
                neutral = 0;
            }

        }
        else
        {
            Opposition += -(x);

            if (Opposition > Population)
                Opposition = Population;


            if (-(x) < neutral)
            {
                neutral -= -(x);
            }
            else
            {

                Supporter = Population - Opposition;
                neutral = 0;

            }
        }

    }



}
