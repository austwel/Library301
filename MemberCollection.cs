using System;
namespace a1 {
    public class MemberCollection {
        private Member[] members;
        private int size;
        public MemberCollection() {
            members = new Member[0];
            size = 0;
        }
        public bool IsEmpty() {
            return size > 0 ? false : true;
        }
        public int Size() {
            return size;
        }
        public bool Contains(string fullname) {
            for(int i = 0; i < size; i++)
                if(members[i] != null && (members[i].Surname+members[i].FirstName).Equals(fullname)) {
                    return true;
                }
            return false;
        }
        public Member Find(string fullname) {
            for(int i = 0; i < size; i++)
                if(members[i] != null && (members[i].Surname+members[i].FirstName).Equals(fullname)) {
                    return members[i];
                }
            return null;
        }
        public int IndexOf(string fullname) {
            if(!Contains(fullname)) return -1;
            for(int i = 0; i < size; i++)
                if(members[i] != null && (members[i].Surname+members[i].FirstName).Equals(fullname)) {
                    return i;
                }
            return -1;
        }
        public bool Remove(string fullname) {
            return RemoveAt(IndexOf(fullname));
        }
        public bool RemoveAt(int index) {
            if(index >= size) return false;
            size--;
            for (int i = 0; i < size; i++) {
                if(i >= index) {
                    members[i] = members[i+1];
                }
            }
            return true;
        }
        public bool Add(Member member) {
            if(member == null) return false;
            Member[] temp = new Member[size + 1];
            for(int i = 0; i < size; i++) {
                temp[i] = members[i];
            }
            temp[size] = member;
            size++;
            members = temp;
            return true;
        }
        public Member MemberAt(int index) {
            if(index >= size) return null;
            return members[index];
        }
        public bool Login(string username, string password) {
            Member user = Find(username);
            if(user != null) {
                if(user.Login(password)) return true;
                return false;
            }
            return false;
        }
        public static MovieCollection GetMovies(Member member) {
            return member.Movies;
        }
    }
}