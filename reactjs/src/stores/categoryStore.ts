import { observable, action } from 'mobx';

import { PagedResultDto } from '../services/dto/pagedResultDto';
import { GetAllCategoryOutput } from '../services/category/dto/getAllCategoryOutput';
import categoryService from '../services/category/categoryService';
import { PagedCategoryResultRequestDto } from '../services/category/dto/PagedCategoryResultRequestDto';

class CategoryStore{
    @observable categories!:PagedResultDto<GetAllCategoryOutput>;
    
    @action async getAll(pagedFilterAndSortedRequest:PagedCategoryResultRequestDto ){
        let result=await categoryService.getAll(pagedFilterAndSortedRequest);
        this.categories=result;
    }
}

export default CategoryStore;