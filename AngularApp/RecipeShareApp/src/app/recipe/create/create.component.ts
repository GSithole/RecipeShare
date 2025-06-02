import { Component } from '@angular/core';
import { RecipeService } from '../recipe.service';
import { Router } from '@angular/router';
import { Recipe } from '../recipe';
import { HttpErrorResponse } from '@angular/common/http';

interface ApiErrors {
  [key: string]: string[]; 
}

@Component({
  selector: 'app-create',
  standalone: false,
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent {

  generalErrorMessage: string | null = null;
  validationErrors: ApiErrors | null = null;


  constructor(private recipeService:RecipeService,private router:Router) {
    
  }

  
  formdata : Recipe = {
    recipeId :0,
    title: '',
    ingredients:'',
    steps:'',
    cookingTimeMinutes:0,
    dietaryTags:''
  }
  returnedError:any
  createRecipe(){
    this.generalErrorMessage = null;
    this.validationErrors = null; 

    this.recipeService.createRecipe(this.formdata).subscribe({
      next:(data:any) =>{
        this.router.navigate(["recipe/home"]);
      },
      error: (error:HttpErrorResponse) => {
        console.log(error)
        if (error.error && error.error.errors) {
          this.validationErrors = error.error.errors;
          this.generalErrorMessage = error.error.message;
        }
        else if (error.error && error.error.message) {
          this.generalErrorMessage = error.error.message;
        } else if (error.status === 0) {
          this.generalErrorMessage = 'A network error occurred.';
        } else {
          this.generalErrorMessage = `Server error: ${error.status} ${error.statusText || ''}`;
        }
      }
    })
  }
}
