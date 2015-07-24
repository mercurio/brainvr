using UnityEngine;
using System.Collections;


/*
 * Handle spoken brain part labels
 */
using UnityEngine.EventSystems;


public class SpeechCenter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TTSManager.Initialize(transform.name, "OnTTSInit");
	}
	

	
	public void say(string s) {
		TTSManager.Speak (s, true);
	}

	/**
	 * Methods to announce each of the brain parts
	 **/

	public void say_amygdala() {
		say("amygdala");
	}

	public void say_brainstem() {
		say("brainstem");
	}

	public void say_brocas_area() {
		say("Broca's area");
	}

	public void say_caudate() {
		say("caudate");
	}

	public void say_cerebellum() {
		say("cerebellum");
	}

	public void say_corpus_callosum() {
		say("corpus callosum");
	}

	public void say_cortex_left() {
		say("left cortex");
	}

	public void say_cortex_right() {
		say("right cortex");
	}

	public void say_fornix() {
		say("fornix");
	}

	public void say_globus_pallidus() {
		say("globus pallidus");
	}

	public void say_hippocampus() {
		say("hippocampus");
	}

	public void say_hypothalamus() {
		say("hypothalamus");
	}

	public void say_limbic_cortex() {
		say("limbic cortex");
	}

	public void say_mammillary_bodies() {
		say("mammillary bodies");
	}

	public void say_mammillo_thalamic_tract() {
		say("mammillo-thalamic tract");
	}

	public void say_pineal() {
		say("pineal");
	}

	public void say_pituitary() {
		say("pituitary");
	}

	public void say_putamen() {
		say("putamen");
	}

	public void say_red_nucleus() {
		say("red nucleus");
	}

	public void say_septum() {
		say("septum");
	}

	public void say_substantia_nigra() {
		say("substantia nygra");
	}

	public void say_subthalamic_nucleus() {
		say("subthalamic nucleus");
	}

	public void say_thalamus() {
		say("thalamus");
	}

	public void say_ventricles() {
		say("ventricles");
	}

	public void say_wernickes_area() {
		say("Wernicke's area");
	}

}
