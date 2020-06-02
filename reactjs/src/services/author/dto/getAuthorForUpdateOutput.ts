export interface Author {
    id: number;
    userId: number
    isActive: boolean;
    isDeleted: boolean;
}
export interface GetAuthorForUpdateOutput {
    author: Author
}