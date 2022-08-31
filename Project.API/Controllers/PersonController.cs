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


        //Gets json type person information.It draws. Matches choser and chosen persons
                [HttpPost("Draw")]
        public async Task<IActionResult> DrawMethod([FromBody] List<Person> personList)
        {
            bool isController=true;
            int size = personList.Count();
            List<int> secondPersonList = new List<int>(); //It keeps the index information of the people. Random selection is made according to this list
            for (int i = 0; i < size; i++)
            {
                secondPersonList.Add(i);
            }

            List<DrawedUserDTO> returnList = new List<DrawedUserDTO>();  //keeps the dto to be returned

            for (int i = 0; i < size; i++)
            {
                isController=true;
                DrawedUserDTO user=new DrawedUserDTO();
                
                
                Random random = new Random();
                int number = random.Next(secondPersonList.Count);
                
                

                if (secondPersonList[number] == i) //It checks whether the person pulls himself or not. Continues until someone else withdraws
                {
                    
                    do
                    {
                        Random random2 = new Random();
                        int number2 = random2.Next(secondPersonList.Count);
                        number = number2;
                        
                        if (secondPersonList.Count()==1) //If the last person draws himself, it clears the lists and makes the draw all over again.
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
                if(isController)  //checks if the previous loop has been exited with a break status
                {
                    user.ChoserUser = personList[i];
                    user.ChosenUser = personList[secondPersonList[number]];
                    returnList.Add(user);
                    secondPersonList.RemoveAt(number);
                }


            }

            
            return Ok(returnList);
        }


        //Gets json type person information. Makes pairs of persons. Returns two persons groups as results
                [HttpPost("Matching")]
        public async Task<IActionResult> MatchingMethod([FromBody] List<Person> personList)
        {
            int groupNumber;
            int size = personList.Count(); //keeps the dto to be returned
            List<int> numberList = new List<int>(); //It keeps the index information of the people. Random selection is made according to this list
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
            if (size % 2 != 0) //If the number of people is odd, 1 person will be alone
            {
                MatchedUserDTO user = new MatchedUserDTO();
                user.FirstUser = personList[numberList[0]];
                user.SecondUser = new Person()
                {   
                    Id = 0,  //the unmatched person is kept in the list with an empty person with id=0
                    Name = "bay",
                    Surname = "bay",
                };
                returnMatchList.Add(user);

            }



            return Ok(returnMatchList);
        }
        
        

    }
}