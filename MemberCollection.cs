using System;
namespace a1 {
    public class MemberCollection {
        //Array class member to store Member objects
        private Member[] members;
        private int size;
        public MemberCollection() {
            members = new Member[0];
            size = 0;
        }
        //Checks if collection has items
        //Input: None
        //Output: bool array emptiness
        public bool IsEmpty() {
            return size > 0 ? false : true;
        }
        //Returns current size of collection
        //Input: None
        //Output: int size of array
        public int Size() {
            return size;
        }
        //Checks if collection contains an object with a certain name
        //Input: string name
        //Output: bool collection does contain object with name
        public bool Contains(string fullname) {
            for(int i = 0; i < size; i++)
                if(members[i] != null && (members[i].Surname+members[i].FirstName).Equals(fullname)) {
                    return true;
                }
            return false;
        }
        //Checks if collection contains an object with a certain name
        //Input: string name
        //Output: Member object which contains given name
        public Member Find(string fullname) {
            for(int i = 0; i < size; i++)
                if(members[i] != null && (members[i].Surname+members[i].FirstName).Equals(fullname)) {
                    return members[i];
                }
            return null;
        }
        //Returns index of a certain user in the collection
        //Input: string name
        //Output: int index
        public int IndexOf(string fullname) {
            if(!Contains(fullname)) return -1;
            for(int i = 0; i < size; i++)
                if(members[i] != null && (members[i].Surname+members[i].FirstName).Equals(fullname)) {
                    return i;
                }
            return -1;
        }
        //Removes a member from the collection
        //Input: string name
        //Output: bool successfully removed
        public bool Remove(string fullname) {
            return RemoveAt(IndexOf(fullname));
        }
        //Removes a member from the collection at a given index
        //Input: int index
        //Output: bool successfully removed
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
        //Adds a member into the array at the end
        //Input: Member member
        //Output: bool successfully added
        public bool Add(Member member) {
            if(member == null) return false;
            Member[] temp = new Member[size + 1]; //Since arrays are immutable, creates a new array
            for(int i = 0; i < size; i++) {       //with 1 extra length and moves over old elements
                temp[i] = members[i];
            }
            temp[size] = member;
            size++;
            members = temp;
            return true;
        }
        //Returns a member at a given index
        //Input: int index
        //Output: Member at that index
        public Member MemberAt(int index) {
            if(index >= size) return null;
            return members[index];
        }
        //Attempts to log into a given username's account with a password
        //Input: string username, string password
        //Output: bool successful login
        public bool Login(string username, string password) {
            Member user = Find(username);
            if(user != null) {
                if(user.Login(password)) return true;
                return false;
            }
            return false;
        }
        //Returns the collection of movies currently being borrowed by a member
        //Input: Member member
        //Output: MovieCollection movies
        public static MovieCollection GetMovies(Member member) {
            return member.Movies;
        }
    }
}