using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MinStackTest
{
    public static class Utility
    {
        //Clean input strings
        private static string removeNonAlphanumericChars(string inString)
        {
            if (string.IsNullOrEmpty(inString)) return string.Empty;
            return Regex.Replace(inString, "[^-a-zA-Z0-9]", string.Empty);
        }

        //Precess object - method and values input strings
        public static string processMinStackMethods(string objectsString, string valuesString)
        {
            if (string.IsNullOrEmpty(objectsString) || string.IsNullOrEmpty(valuesString)) return string.Empty;

            string[] inParmFunc = objectsString.Split(',');
            string[] inValueData = valuesString.Split(',');


            if (inParmFunc.Length != inValueData.Length)
            {
                Console.WriteLine("Invalid Arguments: Imput parameters size mismatch!");
                return string.Empty;
            }

            string objectString = string.Empty;
            string objectValue = string.Empty;
            Type objectName = null;
            object objectInstance = null;
            MethodInfo method = null;

            //Output string container
            StringBuilder sb = new StringBuilder("[");

            //Loop through object - method input list
            for (int j = 0; j < inParmFunc.Length; j++)
            {
                //Clean MinStack object or method string
                objectString = removeNonAlphanumericChars(inParmFunc[j]);

                //Clean input value string
                objectValue = removeNonAlphanumericChars(inValueData[j]);

                if (j == 0)
                {
                    //Get MinStack qualified class name
                    objectName = Assembly.GetExecutingAssembly().GetType("MinStackTest." + objectString);

                    if (objectName == null)
                    {
                        Console.WriteLine("Invalid object name: " + objectString);
                        break;
                    }

                    //Create instance of Object class
                    objectInstance = Activator.CreateInstance(objectName);
                    sb.Append("null");
                }
                else
                {
                    //Get the method from string name
                    method = (MethodInfo)objectName.GetMethod(objectString);
                    if (method != null)
                    {
                        try
                        {
                            if (string.IsNullOrEmpty(objectValue))
                            {
                                if (method.ReturnType == typeof(void))
                                {
                                    method.Invoke(objectInstance, new object[] { });
                                    sb.Append(",null");
                                }
                                else
                                {
                                    var result = method.Invoke(objectInstance, new object[] { });
                                    sb.Append("," + result);
                                }
                            }
                            else
                            {
                                if (method.ReturnType == typeof(void))
                                {
                                    method.Invoke(objectInstance, new object[] { Int32.Parse(objectValue) });
                                    sb.Append(",null");
                                }
                                else
                                {
                                    var result = method.Invoke(objectInstance, new object[] { Int32.Parse(objectValue) });
                                    sb.Append("," + result);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Invalid input parameters: " + e.Message);
                            sb.Append(",null");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid method name: " + objectString);
                        sb.Append(",null"); 
                    }
                }
            }
            sb.Append("]");
            return sb.ToString();
        }

        //Validate parenthesis input expression
        public static bool isValidParensExpression(string inString)
        {
            //Valid characters for parenthesis expressions
            const string AllowableCharacters = "()[]{}";

            //Stack container for parentheses characters
            ParenthesesStack ps = new ParenthesesStack();

            if (string.IsNullOrEmpty(inString)) return false;

            //Loop thru all characters in input expression
            for (int i = 0; i < inString.Length; i++)
            {
                if (AllowableCharacters.IndexOf(inString[i]) == -1)
                {
                    Console.WriteLine("Invalid input expression. Only the following characters are allowed: '(', ')', '{', '}', '[' and ']'");
                    return false;
                }

                //Check if stack is not empty
                if (!ps.stackEmpty())
                {
                    
                    switch (inString[i])
                    {
                        case ')':
                            if (ps.top().Equals('(')) ps.pop();
                            else return false;
                            break;

                        case ']':
                            if (ps.top().Equals('[')) ps.pop();
                            else return false;
                            break;

                        case '}':
                            if (ps.top().Equals('{')) ps.pop();
                            else return false;
                            break;

                        default:
                            ps.push(inString[i]);
                            break;
                    }
                }
                else
                {
                    if (")]}".IndexOf(inString[i]) != -1) return false;
                    ps.push(inString[i]);
                }
            }
            
            if (ps.stackEmpty()) return true;
            else return false;
        }

    }
}
