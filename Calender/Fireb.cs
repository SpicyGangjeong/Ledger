using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Response;
using Newtonsoft.Json;

namespace Ledger {
    internal class Fireb {
        static string _id = "test_id" + "/";
        /// <summary>
        /// 노드를 추가합니다.
        /// 클라이언트 객체, 노드의 경로와 입력값을 파라미터로 요구합니다.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="route"></param>
        /// <param name="data"></param>
        public static bool AddNode(FirebaseClient client, string route, object data) {
            try {
                FirebaseResponse response = client.Set(_id + route, data);
                if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                    return true;
                }
                return false;
            } catch (Exception e) { }
            return false;
        }
        /// <summary>
        /// 노드의 존재여부를 확인합니다. 클라이언트 객체, 노드의 경로를 파라미터로 요구합니다.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        public static bool IsNodeExists(FirebaseClient client, string route) {
            try {
                FirebaseResponse response = client.Get(_id + route);
                if (!response.Body.Equals("null")) {
                    return true;
                }
                return false;
            } catch (Exception e) { }
            return false;
        }
        /// <summary>
        /// <para>노드의 값을 반환합니다. 클라이언트 객체, 노드의 경로를 파라미터로 요구합니다. </para>
        /// <para>예) string a = Fireb.GetNode&lt;string>(client, "NODE");</para>
        /// <para>예) int a = Fireb.GetNode&lt;int>(client, "NODE");</para>
        /// </summary>
        /// <param name="client"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        public static T GetNode<T>(FirebaseClient client, string route) {
            try {
                FirebaseResponse response = client.Get(_id + route);
                if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                    return response.ResultAs<T>();
                }
                return default(T);
            }
            catch (Exception e) { }
            return default(T);
        }
        /// <summary>
        /// 노드를 제거합니다. 클라이언트 객체와 노드의 경로를 파라미터로 요구합니다.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        public static bool DropNode(FirebaseClient client, string route) {
            FirebaseResponse response = client.Get(_id + route);
            if (!response.Body.Equals("null")) { //노드가 존재할 경우
                try {
                    response = client.Delete(_id + route);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                        return true;
                    }
                    return false;
                }
                catch (Exception e) {}
            }
            return false;
        }
        /// <summary>
        /// 회원가입 시, 파이어베이스의 노드를 초기화합니다. 클라이언트 객체를 파라미터로 요구합니다.
        /// </summary>
        /// <param name="client"></param>
        public static void InitUserNode(FirebaseClient client) {
            // 업적 데이터 추가
            for (int i = 0; i < 20; i++) {
                Fireb.AddNode(client, $"ach/ach{i}/cnt", 0);
                Fireb.AddNode(client, $"ach/ach{i}/get", 0);
            }
        }
        /// <summary>
        /// 모든 업적 데이터를 딕셔너리 형태로 저장하여 반환합니다.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static Dictionary<string, Dictionary<string, string>> GetAchNodeValues(FirebaseClient client) {
            Dictionary<string, Dictionary<string, string>> achNodeValues = new Dictionary<string, Dictionary<string, string>>();

            FirebaseResponse response = client.Get(_id + "ach");

            if (response.Body != "null") {
                dynamic data = JsonConvert.DeserializeObject(response.Body);

                foreach (var childNode in data) {
                    string childNodeName = ((Newtonsoft.Json.Linq.JProperty)childNode).Name;

                    // cnt와 get 노드의 값을 가져오기
                    string cntValue = childNode.Value.cnt;
                    string getValue = childNode.Value.get;

                    // 결과를 Dictionary에 추가
                    Dictionary<string, string> childNodeValues = new Dictionary<string, string>
                    {
                    { "cnt", cntValue },
                    { "get", getValue }
                };

                    achNodeValues.Add(childNodeName, childNodeValues);
                }
            }
            return achNodeValues;
        }
        /*
        private void ShowAch(object sender, EventArgs args) {
            Dictionary<string, Dictionary<string, string>> achNodeValues = Fireb.GetAchNodeValues(client);
            string str = "";
            foreach (var kvp in achNodeValues) {
                str += $"Child Node: {kvp.Key}, cnt: {kvp.Value["cnt"]}, get: {kvp.Value["get"]}\n";
            }
            MessageBox.Show(str);
            //MessageBox.Show(achNodeValues["ach0"]["cnt"]);

        }
        */
    }
}
