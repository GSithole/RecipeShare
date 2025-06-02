import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Recipe } from './recipe';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {

  constructor(private http:HttpClient) { }
  GetAllRecipes(){
    return this.http.get<Recipe[]>('http://localhost:5049/api/Recipes');
  }

  createRecipe(data:Recipe){
    return this.http.post('http://localhost:5049/api/Recipes',data);
  }
  
  GetRecipe(recipeid:number){
    return this.http.get<Recipe>(`http://localhost:5049/api/Recipes/${recipeid}`);
  }

  UpdateRecipe(data:Recipe){
    return this.http.put<Recipe>(`http://localhost:5049/api/Recipes/`,data);
  }

  deleteRecipe(recipeid:number){
    return this.http.delete<Recipe>(`http://localhost:5049/api/Recipes/${recipeid}`);
  }
}
