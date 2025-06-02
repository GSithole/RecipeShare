import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../recipe.service';
import { ActivatedRoute, Router } from '@angular/router';
import { response } from 'express';
import { Recipe } from '../recipe';
import { HttpErrorResponse } from '@angular/common/http';

interface ApiErrors {
  [key: string]: string[]; 
}

@Component({
  selector: 'app-edit',
  standalone: false,
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent implements OnInit{

generalErrorMessage: string | null = null;
  validationErrors: ApiErrors | null = null;


  constructor(private recipeService:RecipeService,private router:Router, private activatedRoute:ActivatedRoute) {
    
  }
  formdata : Recipe = {
      recipeId :0,
      title: '',
      ingredients:'',
      steps:'',
      cookingTimeMinutes:0,
      dietaryTags:''
    }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((param) =>{
      let id = Number(param.get('recipeId'))
      this.getById(id)
    })
  }

  getById(id:number){
    this.recipeService.GetRecipe(id).subscribe((response) => {
      this.formdata = response;
    })
  }
  UpdateRecipe(){
    this.generalErrorMessage = null;
    this.validationErrors = null; 
    this.recipeService.UpdateRecipe(this.formdata).subscribe({
      next:(data) =>{
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
