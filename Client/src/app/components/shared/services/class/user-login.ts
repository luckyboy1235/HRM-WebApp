export class UserLogin {
    Username : string;
    Password : string;
    get username(){
        return this.Username;
    }
    set username(username:string){
        this.Username = username;
    }
    get password(){
        return this.Password;
    }
    set password(password:string){
        this.Password = password;
    }
}