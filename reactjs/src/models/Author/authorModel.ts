
import UserModel from '../User/userModel';

class AuthorModel {
    isActive?: boolean;
    user?: UserModel = new UserModel();
    id!: number;
}

export default AuthorModel;