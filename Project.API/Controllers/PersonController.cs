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
        
        

    }
}