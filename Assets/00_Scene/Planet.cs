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

    private double range = 1;//unity unit
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


        //other code here
        //declare
        //int nb = 0 //number of beacon
        //int nbs = 0 //number of broadcast ship
        //int nj = 0 //number of jammer
        //int ns = 0 //0 or 1
        // get jammer 
        //
        // double[] JammedDegree = new double[jammertype.lenght];
        // for(int i = 0; i<jammertype.length;i++)
        //{
        // if( Range+size >= Cal_dis(jammer[i].transform.position))
        //  {
        //      jammedDegree[nj] = Cal_degree(jammer[i].transform.position);
        //      nj++;
        //  }
        //}

        //get beacon type
        //for each beacon
        //{
        //if(Range+size>cal_dis(beacon[i].transform.position))
        //{
        // bool checkJam = false;
        //  
        // for each jammed degree
        //      if(inJammedDegree(beacon[i].transform.position))
        //             checkJam=true;
        //
        // if(!checkjam)
        //  nb++;
        //}
        //
        //}

        //get broadcast ship type

        //for each broastcsat ship
        //{
        //if(Range+size>cal_dis(BCS[i].transform.position))
        //{
        // bool checkJam = false;
        //  
        // for each jammed degree
        //      if(inJammedDegree(BCS[i].transform.position))
        //             checkJam=true;
        //
        // if(!checkjam)
        //  nbs++;
        //}
        //
        //}

        //get ship
        //
        //if mother ship is transmitting 
        //{
        //if(Range+size>cal_dis(ship.transform.position))
        //{
        // bool checkJam = false;
        //  
        // 
        //      if(inJammedDegree(ship.transform.position))
        //             checkJam=true;
        //
        // if(!checkjam)
        //  ns=1;
        //}
        //
        //}

        //calculate signal strenth then add it to the calculation

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
        Oppos_turn += (Opposition * op_mod ) * Time.deltaTime;
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


    bool inJammedDegree(Vector3 pos, double deg)
    {
        if (deg > 315)
            return Cal_Degree(pos) > deg || Cal_Degree(pos) < 45-(360-deg);
        else if (deg < 45)
            return Cal_Degree(pos) < deg || Cal_Degree(pos) > 360 - (45-deg);
        else
            return Cal_Degree(pos) > (deg-45) && Cal_Degree(pos) < (deg+45);

    }
    double Cal_dis(Vector3 pos)
    {
        return Vector3.Distance(this.transform.position, pos);
    }
    double Cal_Degree(Vector3 pos)
    {


        double difx = pos.x - this.transform.position.x ;
        double dify = pos.y - this.transform.position.y ;

        if (difx < 0)
            return (180 + (Mathf.Rad2Deg * Mathf.Atan((float)(dify / difx))));
        else
        {
            if (dify >= 0)
            {
                return (Mathf.Rad2Deg * Mathf.Atan((float)(dify / difx)));
            }
            else
            {
                return (360 + (Mathf.Rad2Deg * Mathf.Atan((float)(dify / difx))));
            }
        }

        
    }



}
