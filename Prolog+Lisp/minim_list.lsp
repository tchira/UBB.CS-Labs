(defun minim_list (l)
"Sa se construiasca o functie care intoarce minimul atomilor numerici
dintr-o lista, de la orice nivel."
(cond ((null l) 32000)
((numberp (car l)) (min (car l) (minim_list (cdr l))))
((atom (car l)) (minim_list (cdr l)))
(t (min (minim_list (car l)) (minim_list (cdr l))))
)
)