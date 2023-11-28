﻿using FireSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ledger {
    internal class AchClass {
        public static readonly int[] achMaxCount = new int[20] {
            10, 20, 30, 10, 20, 30, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1, 1
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
        public static void GetAchievement(FirebaseClient client, int ach_num) {
            int _get = Fireb.GetNode<int>(client, $"{Login.logined_id}/ach/ach{ach_num}/get");
            if (_get == 0) {
                //cnt값 얻어옴
                int _cnt = Fireb.GetNode<int>(client, $"{Login.logined_id}/ach/ach{ach_num}/cnt");
                //1 증가
                Fireb.UpdateNode<int>(client, $"{Login.logined_id}/ach/ach{ach_num}/get", _cnt + 1);
                //만약 획득 조건을 만족하면
                if (Fireb.GetNode<int>(client, $"{Login.logined_id}/ach/ach{ach_num}/cnt") >= AchClass.achMaxCount[ach_num]) {
                    Fireb.UpdateNode<int>(client, $"{Login.logined_id}/ach/ach{ach_num}/get", 1);
                }
                //업적 획득 알림 추가
                //~~
            }
        }
    }
}
