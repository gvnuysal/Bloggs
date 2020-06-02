class UserModel {
    id!: number;
    isActive?: boolean;
    emailAddress!:string;
    fullName?:string;
    name!:string;
    surname!:string;
    userName!:string;
}

export default UserModel;