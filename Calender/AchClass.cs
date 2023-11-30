using FireSharp;
using Ledger.Properties;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ledger {
    internal class AchClass {
        public static readonly int[] achMaxCount = new int[20] {
            10, 20, 30, 10, 20, 30, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1, 1
        };
        public static readonly string[] categories = {
            "식사", "여가", "간식", "주거", "미용", "저축", "교통", "주식", "의료", "게임", "기타"
        };
        public static readonly string[] achName = {
            "소비자", "펑펑", "돈이 삭제가 된다고", "용돈", "알바생",
            "본인 방금 부자되는 상상함", "국밥충", "모히또 가서 리조트",
            "펩시맨", "스위트홈", "어떻게 잘라드릴까요", "티끌모아 태산",
            "어디로 모실까요", "화성 갈끄니까", "아, 병원이오. 안심하세요",
            "어, 형이야", "내 돈이 어디로 갔지?", "존버", "머니게임", "300K"
        };
        public static readonly string[] achText = {
            "지출 내역 추가 10회", "지출 내역 추가 20회",
            "지출 내역 추가 30회", "수입 내역 추가 10회",
            "수입 내역 추가 20회", "수입 내역 추가 30회",
            "소비 분야 [식사] 내역 추가 10회", "소비 분야 [여가] 내역 추가 10회",
            "소비 분야 [간식] 내역 추가 10회", "소비 분야 [주거] 내역 추가 10회",
            "소비 분야 [미용] 내역 추가 10회", "소비 분야 [저축] 내역 추가 10회",
            "소비 분야 [교통] 내역 추가 10회", "소비 분야 [주식] 내역 추가 10회",
            "소비 분야 [의료] 내역 추가 10회", "소비 분야 [게임] 내역 추가 10회",
            "소비 분야 [기타] 내역 추가 10회", "7일 이상의 지출 챌린지 1회 성공",
            "30일 이상의 지출 챌린지 1회 성공", "총 사용액 30만원 이하로 월간 정산하기"
        };
        //업적 테이블에서 해당 아이디의 레코드를 반환합니다
        public static string[] GetAchDatas() {
            string[] array = new string[22];
            string sql = $"select * from tb_ach where f_id = '{Login.logined_id}'";
            MySqlCommand cmd = new MySqlCommand(sql, FormMain.conn);
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read()) {
                array[0] = data["f_spend"].ToString();
                array[1] = data["f_income"].ToString();
                for (var i = 2; i < array.Length; i++) {
                    array[i] = data[$"f_ach{i - 2}"].ToString();
                }
            }
            data.Close();
            return array;
        }
        //총 업적 20개중에 몇 개를 완수했는지 반환합니다
        public static int GetAchProgress(string[] array) {
            int result = 0;
            string[] split;
            for(int i = 2; i < array.Length; i++) {
                
                split = array[i].Split('_');
                //MessageBox.Show(split[split.Length - 1]);
                //하이픈이 0개면 Length = 1, 하이픈이 1개면 Length = 2
                result += split[split.Length - 1].Equals("1") ? 1 : 0; 
            }
            return result;
        }
        //해당 업적이 어느정도의 진행률을 가지고 있는지 반환합니다
        public static int GetAchCnt(string[] array, int index) {
            int result = 0;
            string[] split = array[index + 2].Split('_');
            result = Convert.ToInt32(split[0]);
            return result;
        }
        //지출 내역 추가시에 얻을 수 있는 업적을 관리합니다
        public static void AddAchSpendCount(string cate_name) {
            MySqlCommand cmd;
            MySqlDataReader data;
            int cnt = 0, ach0 = 0, ach1 = 0, ach2 = 0;
            string[] cates = new string[11];
            //데이터 확인
            string sql = $"select f_spend, f_ach0, f_ach1, f_ach2, f_ach6, f_ach7, f_ach8, f_ach9, f_ach10, f_ach11, f_ach12, f_ach13, f_ach14, f_ach15, f_ach16 from tb_ach where f_id = '{Login.logined_id}'";
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();
            while (data.Read()) {
                cnt = Convert.ToInt32(data["f_spend"]);
                ach0 = Convert.ToInt32(data["f_ach0"]);
                ach1 = Convert.ToInt32(data["f_ach1"]);
                ach2 = Convert.ToInt32(data["f_ach2"]);
                for(int i = 0; i < cates.Length; i++) {
                    cates[i] = data[$"f_ach{i + 6}"].ToString();
                }
            }
            cnt++;
            if (ach0 == 0) {
                //10회 업적 미달성시
                if (cnt >= AchClass.achMaxCount[0]) {
                    ach0 = 1;
                    //업적 획득
                    ShowGetAch(Resources.Ach0);
                }
            } else if (ach1 == 0) {
                //20회 업적 미달성시
                if (cnt >= AchClass.achMaxCount[1]) {
                    ach1 = 1;
                    //업적 획득
                    ShowGetAch(Resources.Ach1);
                }
            } else if (ach2 == 0) {
                //30회 업적 미달성시
                if (cnt >= AchClass.achMaxCount[2]) {
                    ach2 = 1;
                    //업적 획득
                    ShowGetAch(Resources.Ach2);
                }
            }
            int ind = Array.IndexOf(categories, cate_name);

            string[] split = cates[ind].Split('_');
            int cate_cnt = Convert.ToInt32(split[0]) + 1;
            int cate_get = Convert.ToInt32(split[1]);
            string column = "";
            if (cate_get == 0) {
                //달성시
                if (cate_cnt >= AchClass.achMaxCount[ind + 6]) {
                    cate_get = 1;
                    column += $", f_ach{ind + 6} = '{cate_cnt}_{cate_get}'";
                    ShowGetAch((System.Drawing.Image)Resources.ResourceManager.GetObject($"Ach{ind + 6}"));
                } else {
                    column += $", f_ach{ind + 6} = '{cate_cnt}_{cate_get}'";
                }
            }
            data.Close();
            sql = $"update tb_ach set f_spend = {cnt}, f_ach0 = {ach0}, f_ach1 = {ach1}, f_ach2 = {ach2} {column} where f_id = '{Login.logined_id}'";
            cmd = new MySqlCommand(sql, FormMain.conn);
            cmd.ExecuteNonQuery();
            
        }
        //수입 내역 추가 시 얻을 수 있는 업적을 관리합니다
        public static void AddAchIncomeCount() {
            MySqlCommand cmd;
            MySqlDataReader data;
            int cnt = 0, ach3 = 0, ach4 = 0, ach5 = 0;
            
            //데이터 확인
            string sql = $"select f_income, f_ach3, f_ach4, f_ach5 from tb_ach where f_id = '{Login.logined_id}'";
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();
            while (data.Read()) {
                cnt = Convert.ToInt32(data["f_income"]);
                ach3 = Convert.ToInt32(data["f_ach3"]);
                ach4 = Convert.ToInt32(data["f_ach4"]);
                ach5 = Convert.ToInt32(data["f_ach5"]);
            }
            cnt++;
            if (ach3 == 0) {
                //10회 업적 미달성시
                if (cnt >= AchClass.achMaxCount[3]) {
                    ach3 = 1;
                    //업적 획득
                    ShowGetAch(Resources.Ach3);
                }
            }
            else if (ach4 == 0) {
                //20회 업적 미달성시
                if (cnt >= AchClass.achMaxCount[4]) {
                    ach4 = 1;
                    //업적 획득
                    ShowGetAch(Resources.Ach4);
                }
            }
            else if (ach5 == 0) {
                //30회 업적 미달성시
                if (cnt >= AchClass.achMaxCount[5]) {
                    ach5 = 1;
                    //업적 획득
                    ShowGetAch(Resources.Ach5);
                }
            }
            data.Close();
            sql = $"update tb_ach set f_income = {cnt}, f_ach3 = {ach3}, f_ach4 = {ach4}, f_ach5 = {ach5} where f_id = '{Login.logined_id}'";
            cmd = new MySqlCommand(sql, FormMain.conn);
            cmd.ExecuteNonQuery();
        }
        //지출 챌린지에서 얻을 수 있는 업적을 관리합니다
        public static void AddAchChallenge(int day) {
            MySqlCommand cmd;
            MySqlDataReader data;
            int ach17 = 0, ach18 = 0;

            //데이터 확인
            string sql = $"select f_ach17, f_ach18 from tb_ach where f_id = '{Login.logined_id}'";
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();

            while (data.Read()) {
                ach17 = Convert.ToInt32(data["f_ach17"]);
                ach18 = Convert.ToInt32(data["f_ach18"]);
            }
            
            if (ach17 == 0) {
                if (day >= 7) {
                    ach17 = 1;
                    //업적 획득
                    ShowGetAch(Resources.Ach17);
                }
            }
            if (ach18 == 0) {
                if (day >= 30) {
                    ach18 = 1;
                    //업적 획득
                    ShowGetAch(Resources.Ach18);
                }
            }
            data.Close();
            sql = $"update tb_ach set f_ach17 = {ach17} and f_ach18 = {ach18} where f_id = '{Login.logined_id}'";
            cmd = new MySqlCommand(sql, FormMain.conn);
            cmd.ExecuteNonQuery();
        }
        //월간 정산에서 얻을 수 있는 업적을 관리합니다
        public static void AddAchMonthly(int money) {
            if (money > 300000) {
                return;
            }
            MySqlCommand cmd;
            MySqlDataReader data;
            int ach19 = 0;
            string sql = $"select f_ach19 from tb_ach where f_id = '{Login.logined_id}'";
            cmd = new MySqlCommand(sql, FormMain.conn);
            data = cmd.ExecuteReader();
            while (data.Read()) {
                ach19 = Convert.ToInt32(data["f_ach19"]);
            }
            data.Close();
            if (ach19 == 1) {
                return;
            } else {
                ach19 = 1;
                sql = $"update tb_ach set f_ach19 = {ach19} where f_id = '{Login.logined_id}'";
                cmd = new MySqlCommand(sql, FormMain.conn);
                cmd.ExecuteNonQuery();
                //업적 획득
                ShowGetAch(Resources.Ach19);
            }
        }
        //업적을 달성하였다는 폼을 띄웁니다
        public static void ShowGetAch(Image img) {
            AchievementGet achForm = new AchievementGet(img);
            achForm.Show();
        }
    }
}
