import { observable, action } from 'mobx';

import { PagedResultDto } from '../services/dto/pagedResultDto';
import { GetAllCategoryOutput } from '../services/category/dto/getAllCategoryOutput';
import categoryService from '../services/category/categoryService';
import { PagedCategoryResultRequestDto } from '../services/category/dto/PagedCategoryResultRequestDto';
import CategoryEditModel from '../models/Category/categoryEditModel';
import { EntityDto } from '../services/dto/entityDto';
import { CreateCategoryInput } from '../services/category/dto/createCategoryInput';
import { UpdateCategoryInput } from '../services/category/dto/updateCategoryInput';

class CategoryStore{
    @observable categories!:PagedResultDto<GetAllCategoryOutput>;
    @observable categoryEdit:CategoryEditModel=new CategoryEditModel();
   
    @action async getAll(pagedFilterAndSortedRequest:PagedCategoryResultRequestDto ){
        let result=await categoryService.getAll(pagedFilterAndSortedRequest);
        this.categories=result;
    }
    @action async createCategory(){
      this.categoryEdit={
          category:{
              id:0,
              name:'',
              description:'',
              isActive:true
          }
      }
    }
    @action async getCategoryForEdit(entityDto:EntityDto){
        let result=await categoryService.getRoleForEdit(entityDto);
        this.categoryEdit.category=result.category;
    }
    @action async create(createCategoryInput:CreateCategoryInput){
        await categoryService.create(createCategoryInput);
    }

    @action async update(updateCategoryInput:UpdateCategoryInput){
        await categoryService.update(updateCategoryInput);
    }
    @action  async delete(entityDto: EntityDto) {

      await categoryService.delete(entityDto);
      this.categories.items = this.categories.items.filter((x: GetAllCategoryOutput) => x.id !== entityDto.id);
    }
}

export default CategoryStore;