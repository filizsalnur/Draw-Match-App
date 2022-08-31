using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Project.Core;
using Newtonsoft.Json;
using WriteState = Newtonsoft.Json.WriteState;


namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {


        /*
          [HttpPost("PersonList")]
          public async Task<IActionResult> PersonListMethod([FromBody] Persons personDTO)
          {
              return Ok(personDTO);
          }*/


        /*
        [HttpPost("Matching")]
        public async Task<IActionResult> MatchingMethod([FromBody] List<Person> personList)
        {
            int groupNumber;
            int size = personList.Count();
            List<int> numberList = new List<int>();
            for (int i = 0; i < size; i++)
            {
                numberList.Add(i);
            }
          
            
            Console.WriteLine("_________________________________________");
            groupNumber = size / 2;
            for (int i = 0; i < groupNumber; i++)
            {
                    
                Random random = new Random();
                int number_1 = random.Next(numberList.Count);

                Console.Write(personList[numberList[number_1]].Id + "-" + personList[numberList[number_1]].Name + " " + personList[numberList[number_1]].Surname+"<---->");
                numberList.RemoveAt(number_1);

                    
                Random random2 = new Random();
                int number_2 = random2.Next(numberList.Count);

                Console.WriteLine(personList[numberList[number_2]].Id + "-" + personList[numberList[number_2]].Name + " " + personList[numberList[number_2]].Surname);
                numberList.RemoveAt(number_2);
                    
            }
            if(size%2!=0)
            {
                Console.WriteLine(personList[numberList[0]].Id + "-" + personList[numberList[0]].Name + " " + personList[numberList[0]].Surname);
            }
            


            return Ok();
        }*/




        /*
        [HttpPost("Draw")]
        public async Task<IActionResult> DrawMethod([FromBody] List<Person> personList)
        {
            int size = personList.Count();
            List<int> secondPersonList = new List<int>();
            for (int i = 0; i < size; i++)
            {
                secondPersonList.Add(i);
            }


            Console.WriteLine("_________________________________________");

            for (int i = 0; i < size; i++)
            {
                

                Console.Write(personList[i].Id + "-" + personList[i].Name + " " + personList[i].Surname + "---->");
                
                Random random = new Random();
                int number = random.Next(secondPersonList.Count);
                if (secondPersonList[number] == i)
                {
                    Random random2 = new Random();
                    int number2 = random2.Next(secondPersonList.Count);
                    number = number2;
                }

                Console.WriteLine(personList[secondPersonList[number]].Id + "-" + personList[secondPersonList[number]].Name + " " + personList[secondPersonList[number]].Surname);
                secondPersonList.RemoveAt(number);

            }



            return Ok();
        } */





        /*
        [HttpGet("Test")]
        public async Task<IActionResult> Get()
        {
            return Ok(new Person { Name = "Filiz", Surname = "Salnur", Id = 1 });
        }*/





        /*
        [HttpPost("Input")]
        public async Task<IActionResult> PersonMethod([FromBody] List<Person> personList)
        {

            return Ok(personList);
        }
        */




        /*
        [HttpPost("Esleme")]
        public async Task<IActionResult> PersonMethod([FromBody] List<Person> personList)
        {
            int size = personList.Count();
            List<int> numberList = new List<int>();
            for (int i = 0; i < size; i++)
            {
                numberList.Add(i);
            }

            numberList.Remove(1);
            for (int i = 0; i < size - 1; i++)
            {
                Console.WriteLine(personList[numberList[i]].Id + "-" + personList[numberList[i]].Name + " " + personList[numberList[i]].Surname);

            }


            return Ok(numberList);
        }
        */

        [HttpPost("Draw")]
        public async Task<IActionResult> DrawMethod([FromBody] List<Person> personList)
        {
            bool isController=true;
            int size = personList.Count();
            List<int> secondPersonList = new List<int>();
            for (int i = 0; i < size; i++)
            {
                secondPersonList.Add(i);
            }

            List<DrawedUserDTO> returnList = new List<DrawedUserDTO>();

            for (int i = 0; i < size; i++)
            {
                isController=true;
                DrawedUserDTO user=new DrawedUserDTO();
                
                
                Random random = new Random();
                int number = random.Next(secondPersonList.Count);
                
                

                if (secondPersonList[number] == i)
                {
                    
                    do
                    {
                        Random random2 = new Random();
                        int number2 = random2.Next(secondPersonList.Count);
                        number = number2;
                        
                        if (secondPersonList.Count()==1)
                        {

                            returnList.Clear();
                            secondPersonList.Clear();


                            i = -1;
                            
                            for (int j = 0; j < size; j++)
                            {
                                secondPersonList.Add(j);
                            }

                            isController = false;
                            break;
                        }
                    } while (secondPersonList[number]== i );
                    
                }
                if(isController) 
                {
                    user.ChoserUser = personList[i];
                    user.ChosenUser = personList[secondPersonList[number]];
                    returnList.Add(user);
                    secondPersonList.RemoveAt(number);
                }


            }

            
            return Ok(returnList);
        }
       
        
        [HttpPost("Matching")]
        public async Task<IActionResult> MatchingMethod([FromBody] List<Person> personList)
        {
            int groupNumber;
            int size = personList.Count();
            List<int> numberList = new List<int>();
            List<MatchedUserDTO> returnMatchList = new List<MatchedUserDTO>();

            for (int i = 0; i < size; i++)
            {
                numberList.Add(i);
            }


            groupNumber = size / 2;
            for (int i = 0; i < groupNumber; i++)
            {
                MatchedUserDTO user = new MatchedUserDTO();
                

                Random random = new Random();
                int number_1 = random.Next(numberList.Count);

                user.FirstUser = personList[numberList[number_1]];


                numberList.RemoveAt(number_1);


                Random random2 = new Random();
                int number_2 = random2.Next(numberList.Count);

                user.SecondUser = personList[numberList[number_2]];

                returnMatchList.Add(user);

                numberList.RemoveAt(number_2);

            }
            if (size % 2 != 0)
            {
                Console.WriteLine(personList[numberList[0]].Id + "-" + personList[numberList[0]].Name + " " + personList[numberList[0]].Surname);

                MatchedUserDTO user = new MatchedUserDTO();
                user.FirstUser = personList[numberList[0]];
                user.SecondUser = new Person()
                {
                    Id = 0,
                    Name = "bay",
                    Surname = "bay",
                };
                returnMatchList.Add(user);

            }



            return Ok(returnMatchList);
        }
        

        /*
        [HttpPost("Draw")]
        public async Task<IActionResult> DrawMethod([FromBody] List<Person> personList)
        {
            int size = personList.Count();
            List<int> secondPersonList = new List<int>();
            for (int i = 0; i < size; i++)
            {
                secondPersonList.Add(i);
            }

            List<Person> returnList = new List<Person>();

            Console.WriteLine("_________________________________________");

            for (int i = 0; i < size; i++)
            {


                Console.Write(personList[i].Id + "-" + personList[i].Name + " " + personList[i].Surname + "---->");

                Random random = new Random();
                int number = random.Next(secondPersonList.Count);
                if (secondPersonList[number] == i)
                {
                    Random random2 = new Random();
                    int number2 = random2.Next(secondPersonList.Count);
                    number = number2;
                }

                returnList.Add(personList[secondPersonList[number]]);

                Console.WriteLine(personList[secondPersonList[number]].Id + "-" + personList[secondPersonList[number]].Name + " " + personList[secondPersonList[number]].Surname);
                secondPersonList.RemoveAt(number);
                

            }
            return Ok(returnList);

        }
        */

        /*
        [HttpPost("Matching")]
        public async Task<IActionResult> MatchingMethod([FromBody] List<Person> personList)
        {
            int groupNumber;
            int size = personList.Count();
            List<int> numberList = new List<int>();
            List<Person> returnMatchList = new List<Person>();

            for (int i = 0; i < size; i++)
            {
                numberList.Add(i);
            }


            Console.WriteLine("_________________________________________");
            groupNumber = size / 2;
            for (int i = 0; i < groupNumber; i++)
            {

                Random random = new Random();
                int number_1 = random.Next(numberList.Count);

                Console.Write(personList[numberList[number_1]].Id + "-" + personList[numberList[number_1]].Name + " " + personList[numberList[number_1]].Surname + "<---->");

                returnMatchList.Add(personList[numberList[number_1]]);

                numberList.RemoveAt(number_1);


                Random random2 = new Random();
                int number_2 = random2.Next(numberList.Count);

                Console.WriteLine(personList[numberList[number_2]].Id + "-" + personList[numberList[number_2]].Name + " " + personList[numberList[number_2]].Surname);

                returnMatchList.Add(personList[numberList[number_2]]);

                numberList.RemoveAt(number_2);

            }
            if (size % 2 != 0)
            {
                Console.WriteLine(personList[numberList[0]].Id + "-" + personList[numberList[0]].Name + " " + personList[numberList[0]].Surname );
                returnMatchList.Add(personList[numberList[0]]);
            }



            return Ok(returnMatchList);
        }
        */

    }
}